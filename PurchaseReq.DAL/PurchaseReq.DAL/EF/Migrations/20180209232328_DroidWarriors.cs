using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class DroidWarriors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "BudgetCodes",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    BudgetCodeName = table.Column<string>(nullable: true),
                    DA = table.Column<int>(nullable: false),
                    Function = table.Column<int>(nullable: false),
                    Parent = table.Column<int>(nullable: false),
                    Project = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Type = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    DivisionName = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessJustification = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    DateMade = table.Column<DateTime>(nullable: false),
                    DateOrdered = table.Column<DateTime>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Ordered = table.Column<bool>(nullable: false),
                    StateContract = table.Column<bool>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Order",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "User",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Order",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFOs",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOs", x => new { x.Id, x.EmployeeId, x.DateAdded });
                    table.UniqueConstraint("AK_CFOs_Id", x => x.Id);
                    table.UniqueConstraint("AK_CFOs_DateAdded_EmployeeId_Id", x => new { x.DateAdded, x.EmployeeId, x.Id });
                    table.ForeignKey(
                        name: "FK_CFOs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "User",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chosen = table.Column<bool>(nullable: false),
                    EstimatedAmount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    PaidAmount = table.Column<decimal>(nullable: false),
                    PaidTotal = table.Column<decimal>(nullable: false),
                    QuantityRequested = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorApprovals",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovalId = table.Column<int>(nullable: false),
                    DeniedJustification = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorApprovals_Approval_ApprovalId",
                        column: x => x.ApprovalId,
                        principalSchema: "Order",
                        principalTable: "Approval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupervisorApprovals_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupervisorApprovals_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalSchema: "User",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFOApprovals",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovalId = table.Column<int>(nullable: false),
                    CFOId = table.Column<int>(nullable: false),
                    DeniedJustification = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CFOApprovals_Approval_ApprovalId",
                        column: x => x.ApprovalId,
                        principalSchema: "Order",
                        principalTable: "Approval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFOApprovals_CFOs_CFOId",
                        column: x => x.CFOId,
                        principalSchema: "User",
                        principalTable: "CFOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFOApprovals_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CFOApprovals_ApprovalId",
                schema: "Order",
                table: "CFOApprovals",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOApprovals_CFOId",
                schema: "Order",
                table: "CFOApprovals",
                column: "CFOId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOApprovals_OrderId",
                schema: "Order",
                table: "CFOApprovals",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CategoryId",
                schema: "Order",
                table: "Orders",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                schema: "Order",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                schema: "Order",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OrderId",
                schema: "Order",
                table: "Requests",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorApprovals_ApprovalId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorApprovals_OrderId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorApprovals_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOs_EmployeeId",
                schema: "User",
                table: "CFOs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOs_Id",
                schema: "User",
                table: "CFOs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CFOApprovals",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "SupervisorApprovals",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "BudgetCodes",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Divisions",
                schema: "User");

            migrationBuilder.DropTable(
                name: "CFOs",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "User");
        }
    }
}
