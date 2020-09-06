using Microsoft.EntityFrameworkCore.Migrations;

namespace JogoVarejo_Server.Server.Migrations
{
    public partial class TesteGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_teste_AspNetUsers_UserId",
                table: "T_teste");

            migrationBuilder.DropForeignKey(
                name: "FK_T_teste_T_grupo_GrupoId",
                table: "T_teste");

            migrationBuilder.DropIndex(
                name: "IX_T_teste_GrupoId",
                table: "T_teste");

            migrationBuilder.DropIndex(
                name: "IX_T_teste_UserId",
                table: "T_teste");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "T_teste");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "T_teste");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "T_teste");

            migrationBuilder.RenameColumn(
                name: "TipoUsuarioId",
                table: "T_teste",
                newName: "GrupoOperadorId");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "T_teste",
                newName: "Quanto");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "T_teste",
                newName: "Quando");

            migrationBuilder.AddColumn<int>(
                name: "TesteId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TesteId",
                table: "AspNetUsers",
                column: "TesteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_T_teste_TesteId",
                table: "AspNetUsers",
                column: "TesteId",
                principalTable: "T_teste",
                principalColumn: "TesteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_T_teste_TesteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TesteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TesteId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Quanto",
                table: "T_teste",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "Quando",
                table: "T_teste",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "GrupoOperadorId",
                table: "T_teste",
                newName: "TipoUsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "T_teste",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "T_teste",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "T_teste",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_teste_GrupoId",
                table: "T_teste",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_teste_UserId",
                table: "T_teste",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_T_teste_AspNetUsers_UserId",
                table: "T_teste",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_teste_T_grupo_GrupoId",
                table: "T_teste",
                column: "GrupoId",
                principalTable: "T_grupo",
                principalColumn: "GrupoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
