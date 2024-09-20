using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaStatusLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "statusLivro",
            table: "livro", // Nome da tabela onde será adicionada a coluna
            type: "int", // Tipo da coluna (ajuste conforme necessário)
            nullable: true); // Se for obrigatório ou não
        }
    

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Descricao",
            table: "Livros");
        }
    }
}
