using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Requests_RequestId",
                schema: "Order",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Categories_CategoryId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Items_ItemId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Orders_OrderId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_Approval_ApprovalId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_Orders_OrderId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Addresses_AddressId",
                schema: "Order",
                table: "Vendors");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Divisions_DivisionId",
                schema: "User",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_AspNetUsers_SupervisorId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesBudgetCodes_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "EmployeesBudgetCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesBudgetCodes_AspNetUsers_EmployeeId",
                schema: "User",
                table: "EmployeesBudgetCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                schema: "User",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "CFOApprovals",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Buildings",
                schema: "User");

            migrationBuilder.DropTable(
                name: "CFOs",
                schema: "User");

            migrationBuilder.DropColumn(
                name: "Function",
                schema: "User",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "Parent",
                schema: "User",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "Project",
                schema: "User",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "User",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "Delivered",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Ordered",
                schema: "Order",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "User",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                schema: "User",
                table: "Rooms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "User",
                table: "EmployeesBudgetCodes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "BudgetCodeName",
                schema: "User",
                table: "BudgetCodes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Order",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BudgetAmount",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BudgetCodeId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetAmount_BudgetCodes_BudgetCodeId",
                        column: x => x.BudgetCodeId,
                        principalSchema: "User",
                        principalTable: "BudgetCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campuses",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    CampusName = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campuses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "User",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAmount_BudgetCodeId",
                schema: "User",
                table: "BudgetAmount",
                column: "BudgetCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_AddressId",
                schema: "User",
                table: "Campuses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalSchema: "User",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers",
                column: "RoomId",
                principalSchema: "User",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Requests_RequestId",
                schema: "Order",
                table: "Attachments",
                column: "RequestId",
                principalSchema: "Order",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                schema: "Order",
                table: "Orders",
                column: "StatusId",
                principalSchema: "Order",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Items_ItemId",
                schema: "Order",
                table: "Requests",
                column: "ItemId",
                principalSchema: "Order",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Orders_OrderId",
                schema: "Order",
                table: "Requests",
                column: "OrderId",
                principalSchema: "Order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests",
                column: "VendorId",
                principalSchema: "Order",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_Approval_ApprovalId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "ApprovalId",
                principalSchema: "Order",
                principalTable: "Approval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_Orders_OrderId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "OrderId",
                principalSchema: "Order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Addresses_AddressId",
                schema: "Order",
                table: "Vendors",
                column: "AddressId",
                principalSchema: "User",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Divisions_DivisionId",
                schema: "User",
                table: "Departments",
                column: "DivisionId",
                principalSchema: "User",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                schema: "User",
                table: "Divisions",
                column: "ParentId",
                principalSchema: "User",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_AspNetUsers_SupervisorId",
                schema: "User",
                table: "Divisions",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesBudgetCodes_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "EmployeesBudgetCodes",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesBudgetCodes_AspNetUsers_EmployeeId",
                schema: "User",
                table: "EmployeesBudgetCodes",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Campuses_BuildingId",
                schema: "User",
                table: "Rooms",
                column: "BuildingId",
                principalSchema: "User",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Requests_RequestId",
                schema: "Order",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BudgetCodes_BudgetCodeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Categories_CategoryId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Items_ItemId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Orders_OrderId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_Approval_ApprovalId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_Orders_OrderId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Addresses_AddressId",
                schema: "Order",
                table: "Vendors");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Divisions_DivisionId",
                schema: "User",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_AspNetUsers_SupervisorId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesBudgetCodes_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "EmployeesBudgetCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesBudgetCodes_AspNetUsers_EmployeeId",
                schema: "User",
                table: "EmployeesBudgetCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Campuses_BuildingId",
                schema: "User",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "BudgetAmount",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Campuses",
                schema: "User");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "User",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomName",
                schema: "User",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "User",
                table: "EmployeesBudgetCodes");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Order",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "BudgetCodeName",
                schema: "User",
                table: "BudgetCodes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Function",
                schema: "User",
                table: "BudgetCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Parent",
                schema: "User",
                table: "BudgetCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project",
                schema: "User",
                table: "BudgetCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                schema: "User",
                table: "BudgetCodes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Delivered",
                schema: "Order",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ordered",
                schema: "Order",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Buildings",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    BuildingName = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "User",
                        principalTable: "Addresses",
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
                    EmployeeId = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOs", x => new { x.Id, x.EmployeeId, x.DateAdded });
                    table.UniqueConstraint("AK_CFOs_Id", x => x.Id);
                    table.UniqueConstraint("AK_CFOs_DateAdded_EmployeeId_Id", x => new { x.DateAdded, x.EmployeeId, x.Id });
                    table.ForeignKey(
                        name: "FK_CFOs_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
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
                name: "IX_Buildings_AddressId",
                schema: "User",
                table: "Buildings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOs_EmployeeId",
                schema: "User",
                table: "CFOs",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CFOs_Id",
                schema: "User",
                table: "CFOs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalSchema: "User",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers",
                column: "RoomId",
                principalSchema: "User",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Requests_RequestId",
                schema: "Order",
                table: "Attachments",
                column: "RequestId",
                principalSchema: "Order",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                schema: "Order",
                table: "Orders",
                column: "StatusId",
                principalSchema: "Order",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Items_ItemId",
                schema: "Order",
                table: "Requests",
                column: "ItemId",
                principalSchema: "Order",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Orders_OrderId",
                schema: "Order",
                table: "Requests",
                column: "OrderId",
                principalSchema: "Order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests",
                column: "VendorId",
                principalSchema: "Order",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_Approval_ApprovalId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "ApprovalId",
                principalSchema: "Order",
                principalTable: "Approval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_Orders_OrderId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "OrderId",
                principalSchema: "Order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorApprovals_AspNetUsers_SupervisorId",
                schema: "Order",
                table: "SupervisorApprovals",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Addresses_AddressId",
                schema: "Order",
                table: "Vendors",
                column: "AddressId",
                principalSchema: "User",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Divisions_DivisionId",
                schema: "User",
                table: "Departments",
                column: "DivisionId",
                principalSchema: "User",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                schema: "User",
                table: "Divisions",
                column: "ParentId",
                principalSchema: "User",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_AspNetUsers_SupervisorId",
                schema: "User",
                table: "Divisions",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesBudgetCodes_BudgetCodes_BudgetCodeId",
                schema: "User",
                table: "EmployeesBudgetCodes",
                column: "BudgetCodeId",
                principalSchema: "User",
                principalTable: "BudgetCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesBudgetCodes_AspNetUsers_EmployeeId",
                schema: "User",
                table: "EmployeesBudgetCodes",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                schema: "User",
                table: "Rooms",
                column: "BuildingId",
                principalSchema: "User",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
