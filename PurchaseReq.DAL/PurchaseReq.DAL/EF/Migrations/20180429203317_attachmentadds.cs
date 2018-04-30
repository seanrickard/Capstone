using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class attachmentadds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                schema: "Order",
                table: "Attachments",
                newName: "Content");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                schema: "Order",
                table: "Attachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "Order",
                table: "Attachments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "Order",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "Order",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "Content",
                schema: "Order",
                table: "Attachments",
                newName: "File");
        }
    }
}
