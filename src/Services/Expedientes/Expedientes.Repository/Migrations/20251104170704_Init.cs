using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expedientes.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubTema = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Caratula = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstadoActualId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCreadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expedientes_Estados_EstadoActualId",
                        column: x => x.EstadoActualId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fojas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpedienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fojas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fojas_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectorDesdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectorHastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpedienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimientos_Expedientes_ExpedienteId",
                        column: x => x.ExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_EstadoActualId",
                table: "Expedientes",
                column: "EstadoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Fojas_ExpedienteId",
                table: "Fojas",
                column: "ExpedienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_EstadoId",
                table: "Movimientos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ExpedienteId_Fecha",
                table: "Movimientos",
                columns: new[] { "ExpedienteId", "Fecha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fojas");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
