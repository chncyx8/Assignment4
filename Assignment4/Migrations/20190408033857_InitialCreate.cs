using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    quote = table.Column<float>(nullable: false),
                    bids = table.Column<float>(nullable: false),
                    asks = table.Column<float>(nullable: false),
                    trades = table.Column<float>(nullable: false),
                    systemEvent = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.quote);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Dividend",
                columns: table => new
                {
                    Exdate = table.Column<DateTime>(nullable: false),
                    Payment_date = table.Column<DateTime>(nullable: false),
                    Record_date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    qualified = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividend", x => x.Exdate);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Amount = table.Column<double>(nullable: false),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Amount);
                });

            migrationBuilder.CreateTable(
                name: "ShortInterestList",
                columns: table => new
                {
                    SettlementDate = table.Column<DateTime>(nullable: false),
                    SecurityName = table.Column<string>(nullable: true),
                    CurrentShortInterest = table.Column<int>(nullable: false),
                    PreviousShortInterest = table.Column<int>(nullable: false),
                    PercentChange = table.Column<double>(nullable: false),
                    AverageDailyVolume = table.Column<int>(nullable: false),
                    DaystoCover = table.Column<double>(nullable: false),
                    StockAdjustmentFlag = table.Column<string>(nullable: true),
                    RevisionFlag = table.Column<string>(nullable: true),
                    SymbolinINETSymbology = table.Column<string>(nullable: true),
                    SymbolinCQSSymbology = table.Column<string>(nullable: true),
                    SymbolinCMSSymbology = table.Column<string>(nullable: true),
                    NewIssueFlag = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortInterestList", x => x.SettlementDate);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Dividend");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "ShortInterestList");
        }
    }
}
