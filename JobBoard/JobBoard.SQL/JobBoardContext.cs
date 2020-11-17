using JobBoard.Core.Model;
using JobBoard.SQL.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.SQL
{
    /// <summary>
    /// Acceso a datos de la base
    /// </summary>
    public  class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options)
        {

        }

        /// <summary>
        ///Acceso a la tabla de job
        /// </summary>
        public DbSet<Job> Job { get; set; }

        /// <summary>
        /// Creacion de los models mapeados
        /// </summary>
        /// <param name="b"></param>
        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.ApplyConfiguration(new JobMap());
        }
        }
}
