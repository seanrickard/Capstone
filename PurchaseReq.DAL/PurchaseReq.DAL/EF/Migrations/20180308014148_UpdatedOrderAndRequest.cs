using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class UpdatedOrderAndRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonChosen",
                schema: "Order",
                table: "Requests",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                schema: "Order",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonChosen",
                schema: "Order",
                table: "Requests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                schema: "Order",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
