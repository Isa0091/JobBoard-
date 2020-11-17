using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.Core.DTO;
using JobBoard.Core.DTO.Job.Input;
using JobBoard.Core.Service;
using JobBoard.Extensions;
using JobBoard.Models.Job.Input;
using JobBoard.Models.Job.Output;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public readonly int _cantidadPorPagina;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
            _cantidadPorPagina = 20;
        }

        public async Task<IActionResult> Index(FiltrosJobInputViewModel filtros, int page = 1)
        {
            if (filtros == null)
                filtros = new FiltrosJobInputViewModel();

            ListaJobOutputViewModel listaJobOutputViewModel = await GetJobsVM(filtros, page);
            return View(listaJobOutputViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetJob(Guid? codigo)
        {
            JobInputViewModel jobInputViewmodel = new JobInputViewModel();

            if (codigo == null)
            {
                JobBoard.Core.Model.Job Job = await _jobService.GetJob(codigo.Value);
                jobInputViewmodel = new JobInputViewModel()
                {
                    Codigo = Job.Codigo,
                    Descripcion = Job.Descripcion,
                    Titulo = Job.Titulo,
                    FechaExpiracionJob = Job.FechaExpiracion.ToString("dd/MM/yyyy")
                };
            }

            string html = await this.RenderViewAsync("_DetalleJob", jobInputViewmodel);
            return Json(new { existoso = true, html = html });
        }

        [HttpPost]
        public async Task<IActionResult> GuardarJob(JobInputViewModel jobInputViewModel, FiltrosJobInputViewModel filtros, int page)
        {
            if (!ModelState.IsValid)
            {
                string htmlDocumento = await this.RenderViewAsync("_DetalleJob", jobInputViewModel);
                return Json(new { existoso = false, html = htmlDocumento });
            }

            if (jobInputViewModel.Codigo == null)
                await _jobService.AddNewJob(new NewJobInputDto()
                {
                    Descripcion = jobInputViewModel.Descripcion,
                    Titulo = jobInputViewModel.Titulo,
                    FechaExpiracion = Convert.ToDateTime(jobInputViewModel.FechaExpiracionJob)
                });

            if (jobInputViewModel.Codigo != null)
                await _jobService.Editjob(new EditJobInputDto()
                {
                    Codigo = jobInputViewModel.Codigo.Value,
                    Descripcion = jobInputViewModel.Descripcion,
                    Titulo = jobInputViewModel.Titulo,
                    FechaExpiracion = Convert.ToDateTime(jobInputViewModel.FechaExpiracionJob)
                });

            ListaJobOutputViewModel listaJobOutputViewModel = await GetJobsVM(filtros, page);
            string html = await this.RenderViewAsync("_ListaJob", listaJobOutputViewModel);
            return Json(new { existoso = true, html = html });
        }



        [HttpPost]
        public async Task<IActionResult> EliminarJob(Guid idJob, FiltrosJobInputViewModel filtros)
        {
            await _jobService.DeleteJob(idJob);
            ListaJobOutputViewModel listaJobOutputViewModel = await GetJobsVM(filtros, 1);
            string html = await this.RenderViewAsync("_ListaJob", listaJobOutputViewModel);
            return Json(new { existoso = true, html = html });
        }


        /// <summary>
        /// Crea un viewmodel el cual contiene todos los datos necesarios para mostrar en la vista
        /// </summary>
        /// <param name="filtros"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        private async Task<ListaJobOutputViewModel> GetJobsVM(FiltrosJobInputViewModel filtros, int page)
        {
            DateTimeOffset fechaFin =
                string.IsNullOrEmpty(filtros.FechaExpiracionFin) ? DateTimeOffset.Now.AddMonths(3) : Convert.ToDateTime(filtros.FechaExpiracionFin);

            DateTimeOffset fechaInicio =
               string.IsNullOrEmpty(filtros.FechaExpiracionInicio) ? DateTimeOffset.Now.AddMonths(-3) : Convert.ToDateTime(filtros.FechaExpiracionInicio);

            filtros.FechaExpiracionFin = fechaFin.ToString("dd/MM/yyyy");
            filtros.FechaExpiracionInicio = fechaInicio.ToString("dd/MM/yyyy");

            FiltrosJobInputDto filtrosJobInputDto = new FiltrosJobInputDto()
            {
                FechaExpiracionFin = fechaFin,
                FechaExpiracionInicio = fechaInicio,
                Titulo = filtros.FiltroTitulo
            };

            ResultadoPaginadoDTO<JobBoard.Core.Model.Job> resultado =
                await _jobService.ListadoPaginadoJobAsync(filtrosJobInputDto, _cantidadPorPagina, page);


            ListaJobOutputViewModel listadoJobVm = new ListaJobOutputViewModel()
            {
                Filtros = filtros,
                ListadoJob = resultado.Resultado,
                PagingInfo = new Models.Paging.PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = _cantidadPorPagina,
                    TotalItems = resultado.CantidadTotal
                }
            };

            return listadoJobVm;
        }

    }
}
