using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FinishedUserRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CFOs_EmployeeId",
                schema: "User",
                table: "CFOs");

            migrationBuilder.CreateTable(
                name: "EmployeesBudgetCodes",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BudgetCodeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesBudgetCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesBudgetCodes_BudgetCodes_BudgetCodeId",
                        column: x => x.BudgetCodeId,
                        principalSchema: "User",
                        principalTable: "BudgetCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeesBudgetCodes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "User",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CFOs_EmployeeId",
                schema: "User",
                table: "CFOs",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesBudgetCodes_BudgetCodeId",
                schema: "User",
                table: "EmployeesBudgetCodes",
                column: "BudgetCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesBudgetCodes_EmployeeId",
                schema: "User",
                table: "EmployeesBudgetCodes",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesBudgetCodes",
                schema: "User");

            migrationBuilder.DropIndex(
                name: "IX_CFOs_EmployeeId",
                schema: "User",
                table: "CFOs");

            migrationBuilder.CreateIndex(
                name: "IX_CFOs_EmployeeId",
                schema: "User",
                table: "CFOs",
                column: "EmployeeId");
        }
    }
}
