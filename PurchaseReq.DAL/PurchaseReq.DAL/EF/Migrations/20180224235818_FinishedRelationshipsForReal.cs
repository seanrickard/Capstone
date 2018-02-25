using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FinishedRelationshipsForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                schema: "Order",
                table: "Requests",
                newName: "PaidCost");

            migrationBuilder.RenameColumn(
                name: "EstimatedAmount",
                schema: "Order",
                table: "Requests",
                newName: "EstimatedCost");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMade",
                schema: "Order",
                table: "Orders",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidTotal",
                schema: "Order",
                table: "Requests",
                nullable: false,
                computedColumnSql: "[QuantityRequested] * [PaidCost]",
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedTotal",
                schema: "Order",
                table: "Requests",
                nullable: false,
                computedColumnSql: "[QuantityRequested] * [EstimatedCost]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTotal",
                schema: "Order",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "PaidCost",
                schema: "Order",
                table: "Requests",
                newName: "PaidAmount");

            migrationBuilder.RenameColumn(
                name: "EstimatedCost",
                schema: "Order",
                table: "Requests",
                newName: "EstimatedAmount");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidTotal",
                schema: "Order",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(decimal),
                oldComputedColumnSql: "[QuantityRequested] * [PaidCost]");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMade",
                schema: "Order",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
