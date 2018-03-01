using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FixEmpToDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Divisions_SupervisorId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_SupervisorId",
                schema: "User",
                table: "Divisions",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Divisions_SupervisorId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_SupervisorId",
                schema: "User",
                table: "Divisions",
                column: "SupervisorId",
                unique: true,
                filter: "[SupervisorId] IS NOT NULL");
        }
    }
}
