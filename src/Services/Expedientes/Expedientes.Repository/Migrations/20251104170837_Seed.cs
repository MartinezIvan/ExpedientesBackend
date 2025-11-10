using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Expedientes.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { new Guid("138c7d7f-91a1-49ef-a1b8-383ea0e21248"), "Cerrado" },
                    { new Guid("6ee0e381-e5f1-43e4-9f26-059280df1b32"), "Creado" },
                    { new Guid("d4d07350-31e4-4b84-b726-713a13702a6d"), "EnTramite" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("138c7d7f-91a1-49ef-a1b8-383ea0e21248"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("6ee0e381-e5f1-43e4-9f26-059280df1b32"));

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: new Guid("d4d07350-31e4-4b84-b726-713a13702a6d"));
        }
    }
}
