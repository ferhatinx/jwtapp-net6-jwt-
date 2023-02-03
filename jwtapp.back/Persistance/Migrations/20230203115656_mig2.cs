using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jwtapp.back.Persistance.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Definition" },
                values: new object[] { 1, "Giyim" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Definition" },
                values: new object[] { 2, "Elektronik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
