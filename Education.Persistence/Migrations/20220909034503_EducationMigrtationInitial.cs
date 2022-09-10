using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrtationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Description", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("50b63f8e-c014-4619-bdbf-3808147b1d5a"), "Curso c# prubas unitarias", new DateTime(2022, 9, 8, 22, 45, 3, 186, DateTimeKind.Local).AddTicks(9585), new DateTime(2024, 9, 8, 22, 45, 3, 186, DateTimeKind.Local).AddTicks(9586), 1000m, "Master en pruebas unitarias" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Description", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("7cb0bdca-5964-447d-a427-a3283102642c"), "Curso C# basico", new DateTime(2022, 9, 8, 22, 45, 3, 186, DateTimeKind.Local).AddTicks(9543), new DateTime(2024, 9, 8, 22, 45, 3, 186, DateTimeKind.Local).AddTicks(9554), 56m, "C# Desde cero a master" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Description", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("8401c60f-422f-477c-8d6a-ab9e2716000c"), "Curso java", new DateTime(2022, 9, 8, 22, 45, 3, 186, DateTimeKind.Local).AddTicks(9577), new DateTime(2024, 9, 8, 22, 45, 3, 186, DateTimeKind.Local).AddTicks(9578), 25m, "Master en Java desde las raices" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
