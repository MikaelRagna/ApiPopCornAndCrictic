using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopCornAndCritics.Migrations
{
    /// <inheritdoc />
    public partial class TratamentoDeChaveUnicaNoEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "duracao",
                table: "Movies",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Movies",
                newName: "genre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Movies",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Movies",
                newName: "duracao");
        }
    }
}
