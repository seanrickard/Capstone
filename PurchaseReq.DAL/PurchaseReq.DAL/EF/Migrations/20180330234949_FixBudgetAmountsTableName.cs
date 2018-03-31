using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FixBudgetAmountsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetAmount_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "BudgetAmount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BudgetAmount",
                schema: "User",
                table: "BudgetAmount");

            migrationBuilder.RenameTable(
                name: "BudgetAmount",
                schema: "User",
                newName: "BudgetAmounts");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetAmount_BudgetCodeId",
                schema: "User",
                table: "BudgetAmounts",
                newName: "IX_BudgetAmounts_BudgetCodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BudgetAmounts",
                schema: "User",
                table: "BudgetAmounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetAmounts_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "BudgetAmounts",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetAmounts_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "BudgetAmounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BudgetAmounts",
                schema: "User",
                table: "BudgetAmounts");

            migrationBuilder.RenameTable(
                name: "BudgetAmounts",
                schema: "User",
                newName: "BudgetAmount");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetAmounts_BudgetCodeId",
                schema: "User",
                table: "BudgetAmount",
                newName: "IX_BudgetAmount_BudgetCodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BudgetAmount",
                schema: "User",
                table: "BudgetAmount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetAmount_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "BudgetAmount",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
