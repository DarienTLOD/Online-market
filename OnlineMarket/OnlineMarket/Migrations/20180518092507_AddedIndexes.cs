using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OnlineMarket.Web.Migrations
{
    public partial class AddedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "СhangeDate",
                table: "ExchangeRates",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_СhangeDate",
                table: "ExchangeRates",
                column: "СhangeDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_СhangeDate",
                table: "ExchangeRates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "СhangeDate",
                table: "ExchangeRates",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
