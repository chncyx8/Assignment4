using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment4.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_name",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_name",
                table: "Companies",
                column: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_name",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_name",
                table: "Companies",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");
        }
    }
}
