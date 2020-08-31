using Microsoft.EntityFrameworkCore.Migrations;

namespace JogoVarejo_Server.Server.Migrations
{
    public partial class Back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "AspNetUsers");
        }
    }
}
