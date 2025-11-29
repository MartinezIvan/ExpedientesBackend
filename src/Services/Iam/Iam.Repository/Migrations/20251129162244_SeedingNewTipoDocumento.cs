using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Iam.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedingNewTipoDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("34ed1c14-f92a-4b29-b5e4-4a0fef9e9ec3"), "Cedula de Ciudadania" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "DNI" },
                    { new Guid("e9210cfd-f497-428a-81d9-dd7cae9a0adf"), "Pasaporte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposDocumento",
                keyColumn: "Id",
                keyValue: new Guid("34ed1c14-f92a-4b29-b5e4-4a0fef9e9ec3"));

            migrationBuilder.DeleteData(
                table: "TiposDocumento",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "TiposDocumento",
                keyColumn: "Id",
                keyValue: new Guid("e9210cfd-f497-428a-81d9-dd7cae9a0adf"));
        }
    }
}
