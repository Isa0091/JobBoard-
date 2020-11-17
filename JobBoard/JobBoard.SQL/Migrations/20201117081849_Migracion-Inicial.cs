using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.SQL.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 256, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 1500, nullable: false),
                    FechaExpiracion = table.Column<DateTimeOffset>(nullable: false),
                    FechaIngreso = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
