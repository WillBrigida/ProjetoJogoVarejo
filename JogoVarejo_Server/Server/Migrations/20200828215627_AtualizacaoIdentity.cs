using Microsoft.EntityFrameworkCore.Migrations;

namespace JogoVarejo_Server.Server.Migrations
{
    public partial class AtualizacaoIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeGrupo",
                table: "AspNetUsers",
                newName: "Senha");

            migrationBuilder.AddColumn<int>(
                name: "GrupoUsuarioId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupoUsuarioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "AspNetUsers",
                newName: "NomeGrupo");
        }
    }
}
