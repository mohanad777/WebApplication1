using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1.Migrations
{
    public partial class SeedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "DisplayOrder", "Name" },
                values: new object[] { 1, 1, "Action" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "DisplayOrder", "Name" },
                values: new object[] { 2, 2, "SciFi" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "DisplayOrder", "Name" },
                values: new object[] { 3, 3, "History" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
