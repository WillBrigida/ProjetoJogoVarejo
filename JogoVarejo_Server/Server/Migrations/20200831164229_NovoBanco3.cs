using Microsoft.EntityFrameworkCore.Migrations;

namespace JogoVarejo_Server.Server.Migrations
{
    public partial class NovoBanco3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3519cc00-bf7f-4b02-9e2e-8d04d5b3a14e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478abd7a-a8ba-4757-955c-85aa53997653");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3519cc00-bf7f-4b02-9e2e-8d04d5b3a14e", "b5f676ef-b146-4a47-bea5-7dc08b4cab0a", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "478abd7a-a8ba-4757-955c-85aa53997653", "12cb9e82-6288-49b7-8b11-a4d631b70d37", "Aluno", "ALUNO" });
        }
    }
}
