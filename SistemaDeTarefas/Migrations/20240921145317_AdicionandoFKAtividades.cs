using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFKAtividades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TipoAtividade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LocalAtividade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "localAtividade",
                table: "Atividade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_localAtividade",
                table: "Atividade",
                column: "localAtividade");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_tipoAtividade",
                table: "Atividade",
                column: "tipoAtividade");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_LocalAtividade_localAtividade",
                table: "Atividade",
                column: "localAtividade",
                principalTable: "LocalAtividade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_TipoAtividade_tipoAtividade",
                table: "Atividade",
                column: "tipoAtividade",
                principalTable: "TipoAtividade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_LocalAtividade_localAtividade",
                table: "Atividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_TipoAtividade_tipoAtividade",
                table: "Atividade");

            migrationBuilder.DropIndex(
                name: "IX_Atividade_localAtividade",
                table: "Atividade");

            migrationBuilder.DropIndex(
                name: "IX_Atividade_tipoAtividade",
                table: "Atividade");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TipoAtividade",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "LocalAtividade",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "localAtividade",
                table: "Atividade",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
