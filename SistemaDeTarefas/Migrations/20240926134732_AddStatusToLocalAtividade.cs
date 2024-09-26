using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToLocalAtividade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusLocalAtividade",
                table: "LocalAtividade",
                type: "int",
                nullable: true,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusLocalAtividade",
                table: "LocalAtividade");
        }
    }
}
