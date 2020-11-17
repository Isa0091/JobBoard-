using JobBoard.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.SQL.Repo
{
    /// <summary>
    /// Interfaz que todos los respos deben implementar
    /// </summary>
    public abstract class RepoBase<T> : IRepoBase<T>
    {
        protected JobBoardContext _db;

        protected RepoBase(JobBoardContext context)
        {
            _db = context;
        }

        /// <summary>
        /// se guarda la entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <return>La entiddad ya agregada a la base de datos, es de utilidad para leer autonumericos
        /// o otros campos generados por la base de datos.</return>
        public async Task AgregarAsync(T entidad)
        {
            await _db.AddAsync(entidad);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
