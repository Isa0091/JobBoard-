using JobBoard.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.SQL.Mapping
{
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> b)
        {
            b.HasKey(x => x.Codigo);
            b.Property(x => x.Titulo).HasMaxLength(256).IsRequired();
            b.Property(x => x.Descripcion).HasMaxLength(1500).IsRequired();
            b.Property(x => x.FechaExpiracion).IsRequired();
            b.Property(x => x.FechaIngreso).IsRequired();

        }
    }
}