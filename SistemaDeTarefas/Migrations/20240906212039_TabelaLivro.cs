using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class TabelaLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    idLivro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nomeLivro = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    autorLivro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    quantidadePaginasLivro = table.Column<int>(type: "int", nullable: false),
                    editoraLivro = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.idLivro);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
