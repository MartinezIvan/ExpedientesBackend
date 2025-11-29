using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Iam.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedingNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("291aefbb-1f66-4aff-a30c-6163d726c43c"), "Desarrollo" },
                    { new Guid("c6eb1013-ea61-4f0d-9774-ace21596a02a"), "Diseño" },
                    { new Guid("e69d41f0-5a46-4b9d-840a-dd76d55c92cd"), "Investigacion" },
                    { new Guid("e6f5f7ca-079e-4a5c-b1cb-d03f953a21b2"), "Administracion" },
                    { new Guid("faafefc4-9368-4624-93ac-1b7a734e7000"), "Calidad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: new Guid("291aefbb-1f66-4aff-a30c-6163d726c43c"));

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: new Guid("c6eb1013-ea61-4f0d-9774-ace21596a02a"));

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: new Guid("e69d41f0-5a46-4b9d-840a-dd76d55c92cd"));

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: new Guid("e6f5f7ca-079e-4a5c-b1cb-d03f953a21b2"));

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: new Guid("faafefc4-9368-4624-93ac-1b7a734e7000"));
        }
    }
}
