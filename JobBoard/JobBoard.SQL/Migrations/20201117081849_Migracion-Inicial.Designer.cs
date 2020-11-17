﻿// <auto-generated />
using System;
using JobBoard.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobBoard.SQL.Migrations
{
    [DbContext(typeof(JobBoardContext))]
    [Migration("20201117081849_Migracion-Inicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobBoard.Core.Model.Job", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<DateTimeOffset>("FechaExpiracion")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("FechaIngreso")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Codigo");

                    b.ToTable("Job");
                });
#pragma warning restore 612, 618
        }
    }
}
