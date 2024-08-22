using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Livros.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTitulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Título",
                table: "Livros",
                newName: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Livros",
                newName: "Título");
        }
    }
}
