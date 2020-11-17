using JobBoard.Core.DTO.Job.Input;
using JobBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Service
{
    /// <summary>
    /// maneja los services de acceso al repo de job
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// maneja el agregado de un nuevo trabajo
        /// </summary>
        /// <param name="newJobInputDto"></param>
        /// <returns></returns>
        Task<Job> AddNewJob(NewJobInputDto newJobInputDto);

        /// <summary>
        /// Edita los datos de un job
        /// </summary>
        /// <param name="newJobInputDto"></param>
        /// <returns></returns>
        Task<Job> Editjob(NewJobInputDto newJobInputDto);

        /// <summary>
        /// Elimina los datos de un job
        /// </summary>
        /// <param name="idJob"></param>
        void DeleteJob(Guid idJob);
    }
}
