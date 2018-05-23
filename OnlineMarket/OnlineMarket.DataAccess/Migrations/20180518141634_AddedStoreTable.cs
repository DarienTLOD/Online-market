using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineMarket.Web.Migrations
{
    public partial class AddedStoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Users_UserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationArchive_Account_AccountId",
                table: "OperationArchive");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OperationArchive_AccountId",
                table: "OperationArchive");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AccountOwnerDataModel");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "OperationArchive",
                newName: "AccountToId");

            migrationBuilder.RenameColumn(
                name: "BuyRate",
                table: "ExchangeRates",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Account",
                newName: "AccountOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_UserId",
                table: "Account",
                newName: "IX_Account_AccountOwnerId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AccountOwnerDataModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AccountOwnerDataModel",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountFromId",
                table: "OperationArchive",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOwnerDataModel",
                table: "AccountOwnerDataModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountOwnerDataModel_AccountOwnerId",
                table: "Account",
                column: "AccountOwnerId",
                principalTable: "AccountOwnerDataModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountOwnerDataModel_AccountOwnerId",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOwnerDataModel",
                table: "AccountOwnerDataModel");

            migrationBuilder.DropColumn(
                name: "AccountFromId",
                table: "OperationArchive");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AccountOwnerDataModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AccountOwnerDataModel");

            migrationBuilder.RenameTable(
                name: "AccountOwnerDataModel",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "AccountToId",
                table: "OperationArchive",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "ExchangeRates",
                newName: "BuyRate");

            migrationBuilder.RenameColumn(
                name: "AccountOwnerId",
                table: "Account",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_AccountOwnerId",
                table: "Account",
                newName: "IX_Account_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OperationArchive_AccountId",
                table: "OperationArchive",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Users_UserId",
                table: "Account",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationArchive_Account_AccountId",
                table: "OperationArchive",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
