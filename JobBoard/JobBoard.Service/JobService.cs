using JobBoard.Core.Data;
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
        private readonly IJobRepoitory _jobRepoitory;

        public JobService(IJobRepoitory jobRepoitory)
        {
            _jobRepoitory = jobRepoitory;
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

            await _jobRepoitory.AgregarAsync(job);
            await _jobRepoitory.SaveChangesAsync();

            return job;
        }

        public async Task DeleteJob(Guid idJob)
        {
            Job job = await _jobRepoitory.GetByIdAsync(idJob);

            if (job == null)
                throw new JobException(JobException.TipoErrorJob.NoExiste, "El job al que desea acceder no existe");

            _jobRepoitory.Eliminar(job);
            await _jobRepoitory.SaveChangesAsync();
        }

        public async Task<Job> Editjob(EditJobInputDto editJobInputDto)
        {
            Job job =await _jobRepoitory.GetByIdAsync(editJobInputDto.Codigo);

            if (job == null)
                throw new JobException(JobException.TipoErrorJob.NoExiste, "El job al que desea acceder no existe");

            job.Titulo = editJobInputDto.Titulo;
            job.Descripcion = editJobInputDto.Descripcion;
            job.FechaExpiracion = editJobInputDto.FechaExpiracion;

            await _jobRepoitory.SaveChangesAsync();

            return job;
        }

        public async Task<List<Job>> GetListadoAsync()
        {
            return await _jobRepoitory.GetListadoAsync();
        }
    }
}
