using JobBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Data
{
    /// <summary>
    /// Maneja el acceso a datos de la tabla job
    /// </summary>
    public interface IJobRepoitory : IRepoBase<Job>
    {
        /// <summary>
        /// Obtengo un trabajo por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Job> GetByIdAsync(Guid id);
        /// <summary>
        /// Obtengo un listado de  trabajo
        /// </summary>
        /// <returns></returns>
        Task<List<Job>> GetListadoAsync();
        /// <summary>
        /// Elimina u ntrabaj ode la base de datos
        /// </summary>
        /// <param name="job"></param>
        void Eliminar(Job job);
    }
}
