using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iam.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoTelefonoAUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NroTelefono",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroTelefono",
                table: "Usuarios");
        }
    }
}
