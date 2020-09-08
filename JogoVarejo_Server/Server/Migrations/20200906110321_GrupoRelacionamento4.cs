using Microsoft.EntityFrameworkCore.Migrations;

namespace JogoVarejo_Server.Server.Migrations
{
    public partial class GrupoRelacionamento4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_teste",
                columns: table => new
                {
                    TesteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    GrupoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_teste", x => x.TesteId);
                    table.ForeignKey(
                        name: "FK_T_teste_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_teste_T_grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "T_grupo",
                        principalColumn: "GrupoId",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_teste");
        }
    }
}
