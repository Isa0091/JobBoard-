using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.Core.DTO;
using JobBoard.Core.DTO.Job.Input;
using JobBoard.Core.Service;
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

            ListaJobOutputViewModel  listaJobOutputViewModel = await GetJobsVM(filtros, page);
            return View(listaJobOutputViewModel);
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
                 FechaExpiracionFin= fechaFin,
                 FechaExpiracionInicio= fechaInicio,
                 Titulo= filtros.FiltroTitulo
            };

            ResultadoPaginadoDTO<JobBoard.Core.Model.Job> resultado =
                await _jobService.ListadoPaginadoJobAsync(filtrosJobInputDto, _cantidadPorPagina, page);


            ListaJobOutputViewModel listadoJobVm= new ListaJobOutputViewModel()
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
