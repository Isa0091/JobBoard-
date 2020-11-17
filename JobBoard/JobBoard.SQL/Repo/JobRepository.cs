using JobBoard.Core.Data;
using JobBoard.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
