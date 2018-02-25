using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FinishedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                schema: "Order",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                schema: "Order",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlternativeRequest",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativeId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeRequest_Requests_AlternativeId",
                        column: x => x.AlternativeId,
                        principalSchema: "Order",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlternativeRequest_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "Order",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentPath = table.Column<string>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "Order",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ItemId",
                schema: "Order",
                table: "Requests",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_VendorId",
                schema: "Order",
                table: "Requests",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeRequest_AlternativeId",
                schema: "Order",
                table: "AlternativeRequest",
                column: "AlternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeRequest_RequestId",
                schema: "Order",
                table: "AlternativeRequest",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_RequestId",
                schema: "Order",
                table: "Attachments",
                column: "RequestId");

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
                name: "FK_Requests_Items_ItemId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vendors_VendorId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "AlternativeRequest",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ItemId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_VendorId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "Order",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "Order",
                table: "Requests");
        }
    }
}
