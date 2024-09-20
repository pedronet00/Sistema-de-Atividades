using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class Atividade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    tituloAtividade = table.Column<string>(type: "longtext", nullable: false),
                    descricaoAtividade = table.Column<string>(type: "longtext", nullable: false),
                    localAtividade = table.Column<string>(type: "longtext", nullable: false),
                    dataAtividade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tipoAtividade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");
        }
    }
}
