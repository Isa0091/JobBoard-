using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core.Data
{
    /// <summary>
    /// Repo base el cual todas las entidades deben generar
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoBase<T>
    {
        /// <summary>
        /// Datos agregados a la base
        /// </summary>
        /// <param name="entidad"></param>
        /// <return>La entiddad ya agregada a la base de datos, es de utilidad para leer autonumericos
        /// o otros camos generados por la base de datos.</return>
        Task AgregarAsync(T entidad);
        /// <summary>
        /// Persiste los cambios a la base de datos
        /// </summary>
        Task SaveChangesAsync();
    }
}
