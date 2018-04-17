using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class nullablevendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                schema: "Order",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests",
                column: "VendorId",
                principalSchema: "Order",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                schema: "Order",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests",
                column: "VendorId",
                principalSchema: "Order",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
