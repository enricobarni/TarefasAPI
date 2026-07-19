using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditColunaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Tarefas",
                newName: "DataCriacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Tarefas",
                newName: "Data");
        }
    }
}
