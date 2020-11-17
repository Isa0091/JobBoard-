using JobBoard.Core.Data;
using JobBoard.Core.DTO;
using JobBoard.Core.DTO.Job.Input;
using JobBoard.Core.Exceptions;
using JobBoard.Core.Model;
using JobBoard.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job> AddNewJob(NewJobInputDto newJobInputDto)
        {
            Job job = new Job()
            {
                Codigo = Guid.NewGuid(),
                Descripcion = newJobInputDto.Descripcion,
                FechaExpiracion = newJobInputDto.FechaExpiracion,
                Titulo = newJobInputDto.Titulo
            };

            await _jobRepository.AgregarAsync(job);
            await _jobRepository.SaveChangesAsync();

            return job;
        }

        public async Task DeleteJob(Guid idJob)
        {
            Job job = await _jobRepository.GetByIdAsync(idJob);

            if (job == null)
                throw new JobException(JobException.TipoErrorJob.NoExiste, "El job al que desea acceder no existe");

            _jobRepository.Eliminar(job);
            await _jobRepository.SaveChangesAsync();
        }

        public async Task<Job> Editjob(EditJobInputDto editJobInputDto)
        {
            Job job =await _jobRepository.GetByIdAsync(editJobInputDto.Codigo);

            if (job == null)
                throw new JobException(JobException.TipoErrorJob.NoExiste, "El job al que desea acceder no existe");

            job.Titulo = editJobInputDto.Titulo;
            job.Descripcion = editJobInputDto.Descripcion;
            job.FechaExpiracion = editJobInputDto.FechaExpiracion;

            await _jobRepository.SaveChangesAsync();

            return job;
        }

        public async Task<List<Job>> GetListadoAsync()
        {
            return await _jobRepository.GetListadoAsync();
        }

        public async Task<Job> GetJob(Guid idJob)
        {
            Job job = await _jobRepository.GetByIdAsync(idJob);

            if (job == null)
                throw new JobException(JobException.TipoErrorJob.NoExiste, "El job al que desea acceder no existe");

            return job;
        }

            public async Task<ResultadoPaginadoDTO<Job>> ListadoPaginadoJobAsync(FiltrosJobInputDto filtrosJobInput, int cantidadPorPagina = 20, int paginaActual = 1)
        {
            ResultadoPaginadoDTO<Job> resultadoPaginado = await _jobRepository.ListadoPaginadoJobAsync(filtrosJobInput, cantidadPorPagina, paginaActual);

            return resultadoPaginado;
        }
    }
}
