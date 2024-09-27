using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AlterLocalAtividadeNameAtividade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "localAtividade",         // Nome atual da coluna
            table: "Atividade",             // Nome da tabela onde a coluna está
            newName: "idLocalAtividade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
             name: "idLocalAtividade",
             table: "Atividade",
             newName: "localAtividade");
        }
    }
}
