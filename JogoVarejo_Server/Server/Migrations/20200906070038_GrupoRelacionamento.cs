using Microsoft.EntityFrameworkCore.Migrations;

namespace JogoVarejo_Server.Server.Migrations
{
    public partial class GrupoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GrupoId",
                table: "AspNetUsers",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_T_grupo_GrupoId",
                table: "AspNetUsers",
                column: "GrupoId",
                principalTable: "T_grupo",
                principalColumn: "GrupoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_T_grupo_GrupoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GrupoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "AspNetUsers");
        }
    }
}
