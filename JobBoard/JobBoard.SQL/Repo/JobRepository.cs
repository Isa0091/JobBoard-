using JobBoard.Core.Data;
using JobBoard.Core.DTO;
using JobBoard.Core.DTO.Job.Input;
using JobBoard.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.SQL.Repo
{
    public class JobRepository : RepoBase<Job>, IJobRepoitory
    {

        public JobRepository(JobBoardContext context) : base(context)
        {
        }

        public void Eliminar(Job job)
        {
            _db.Entry(job).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public  async Task<Job> GetByIdAsync(Guid id)
        {
            return await _db.Job.SingleOrDefaultAsync(x => x.Codigo == id);
        }

        public async Task<List<Job>> GetListadoAsync()
        {
            return await _db.Job.ToListAsync();
        }


        public async Task<ResultadoPaginadoDTO<Job>> ListadoPaginadoJobAsync(FiltrosJobInputDto filtrosJobInput, int cantidadPorPagina = 20, int paginaActual = 1)
        {
            bool sinTitulo = string.IsNullOrEmpty(filtrosJobInput.Titulo);

            DateTimeOffset? fechaFinal = filtrosJobInput.FechaExpiracionFin != null ?
                filtrosJobInput.FechaExpiracionFin.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) : (DateTimeOffset?)null;

            Expression<Func<Job, bool>> where = x =>
            (
                 x.FechaExpiracion >= filtrosJobInput.FechaExpiracionInicio && 
                 (fechaFinal == null || x.FechaExpiracion <= fechaFinal)
                && (sinTitulo || x.Titulo.Contains(filtrosJobInput.Titulo))
            );

            List<Job> listaJob = await _db.Job.Where(where)
                .OrderByDescending(x => x.FechaIngreso)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina).ToListAsync();

            int totalResultados = await GetTotalResultadosAsync(where);

            return new ResultadoPaginadoDTO<Job>()
            {
                Resultado = listaJob,
                CantidadTotal = totalResultados
            };
        }

        private async Task<int> GetTotalResultadosAsync(Expression<Func<Job, bool>> predicate)
        {
            return await _db.Job.CountAsync(predicate);
        }
    }
}
