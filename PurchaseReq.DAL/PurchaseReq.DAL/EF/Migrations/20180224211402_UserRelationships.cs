using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class UserRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "User",
                table: "Divisions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                schema: "User",
                table: "Departments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentId",
                schema: "User",
                table: "Divisions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DivisionId",
                schema: "User",
                table: "Departments",
                column: "DivisionId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Divisions_DivisionId",
                schema: "User",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DivisionId",
                schema: "User",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "User",
                table: "Departments");
        }
    }
}
