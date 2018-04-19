using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class OrderManyForApprovals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SupervisorApprovals_OrderId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorApprovals_OrderId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SupervisorApprovals_OrderId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorApprovals_OrderId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "OrderId",
                unique: true);
        }
    }
}
