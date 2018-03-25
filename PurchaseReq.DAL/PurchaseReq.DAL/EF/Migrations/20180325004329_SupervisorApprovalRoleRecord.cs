using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class SupervisorApprovalRoleRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRoleId",
                schema: "Order",
                table: "SupervisorApprovals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorApprovals_UserRoleId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_AspNetRoles_UserRoleId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "UserRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_AspNetRoles_UserRoleId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropIndex(
                name: "IX_SupervisorApprovals_UserRoleId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
