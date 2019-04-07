using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment4.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Financials",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    reportDate = table.Column<string>(nullable: true),
                    grossProfit = table.Column<int>(nullable: false),
                    costOfRevenue = table.Column<int>(nullable: false),
                    operatingRevenue = table.Column<int>(nullable: false),
                    totalRevenue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financials", x => x.name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_name",
                table: "Companies",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Financials_name",
                table: "Companies",
                column: "name",
                principalTable: "Financials",
                principalColumn: "name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Financials_name",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Financials");

            migrationBuilder.DropIndex(
                name: "IX_Companies_name",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
