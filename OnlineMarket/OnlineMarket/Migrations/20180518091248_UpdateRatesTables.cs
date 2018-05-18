using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineMarket.Web.Migrations
{
    public partial class UpdateRatesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentRate_ItemType_ItemTypeId",
                table: "CurrentRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentRate",
                table: "CurrentRate");

            migrationBuilder.DropIndex(
                name: "IX_CurrentRate_ItemTypeId",
                table: "CurrentRate");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CurrentRate");

            migrationBuilder.RenameTable(
                name: "CurrentRate",
                newName: "ExchangeRates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "СhangeDate",
                table: "ExchangeRates",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExchangeRates",
                table: "ExchangeRates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CurrentRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BuyRate = table.Column<decimal>(type: "money", nullable: false),
                    ItemTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentRate_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_ItemTypeId",
                table: "ExchangeRates",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentRate_ItemTypeId",
                table: "CurrentRate",
                column: "ItemTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_ItemType_ItemTypeId",
                table: "ExchangeRates",
                column: "ItemTypeId",
                principalTable: "ItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_ItemType_ItemTypeId",
                table: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "CurrentRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExchangeRates",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_ItemTypeId",
                table: "ExchangeRates");

            migrationBuilder.RenameTable(
                name: "ExchangeRates",
                newName: "CurrentRate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "СhangeDate",
                table: "CurrentRate",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CurrentRate",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentRate",
                table: "CurrentRate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentRate_ItemTypeId",
                table: "CurrentRate",
                column: "ItemTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentRate_ItemType_ItemTypeId",
                table: "CurrentRate",
                column: "ItemTypeId",
                principalTable: "ItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
