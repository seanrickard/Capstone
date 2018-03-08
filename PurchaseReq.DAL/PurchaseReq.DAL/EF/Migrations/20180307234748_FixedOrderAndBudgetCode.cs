using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FixedOrderAndBudgetCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetCodeId",
                schema: "Order",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BudgetCodeId",
                schema: "Order",
                table: "Orders",
                column: "BudgetCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BudgetCodeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BudgetCodeId",
                schema: "Order",
                table: "Orders");
        }
    }
}
