using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class UpdateOrderForNullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Categories_CategoryId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "Order",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BudgetCodeId",
                schema: "Order",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Categories_CategoryId",
                schema: "Order",
                table: "Orders",
                column: "CategoryId",
                principalSchema: "Order",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Categories_CategoryId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "Order",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BudgetCodeId",
                schema: "Order",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Categories_CategoryId",
                schema: "Order",
                table: "Orders",
                column: "CategoryId",
                principalSchema: "Order",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
