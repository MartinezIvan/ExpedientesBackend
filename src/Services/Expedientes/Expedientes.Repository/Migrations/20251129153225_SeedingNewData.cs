using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Expedientes.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedingNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdSectorActual",
                table: "Expedientes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("1907e192-d38e-4564-a949-cfad5af7ee0a"), "Aprobado" },
                    { new Guid("1fbf4dc3-cb0c-405e-b0a4-9ea72076b637"), "Rechazado" },
                    { new Guid("80d71e53-5ab3-418b-91ed-980b2e40595e"), "Completado" },
                    { new Guid("be14b378-9742-4c20-bdfe-0bf9d8eacc0e"), "En progreso" },
                    { new Guid("e5b8de27-5d78-457a-913d-89a4e634b0c6"), "En revisión" },
                    { new Guid("fc43dac0-a951-4107-86e5-d63cdaf764e2"), "Creado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("1907e192-d38e-4564-a949-cfad5af7ee0a"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("1fbf4dc3-cb0c-405e-b0a4-9ea72076b637"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("80d71e53-5ab3-418b-91ed-980b2e40595e"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("be14b378-9742-4c20-bdfe-0bf9d8eacc0e"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("e5b8de27-5d78-457a-913d-89a4e634b0c6"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("fc43dac0-a951-4107-86e5-d63cdaf764e2"));

            migrationBuilder.DropColumn(
                name: "IdSectorActual",
                table: "Expedientes");
        }
    }
}
