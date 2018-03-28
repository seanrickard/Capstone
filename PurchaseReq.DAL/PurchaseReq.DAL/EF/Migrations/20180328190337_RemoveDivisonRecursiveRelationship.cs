using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class RemoveDivisonRecursiveRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Campuses_BuildingId",
                schema: "User",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "User",
                table: "Divisions");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                schema: "User",
                table: "Rooms",
                newName: "CampusId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BuildingId",
                schema: "User",
                table: "Rooms",
                newName: "IX_Rooms_CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Campuses_CampusId",
                schema: "User",
                table: "Rooms",
                column: "CampusId",
                principalSchema: "User",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Campuses_CampusId",
                schema: "User",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "CampusId",
                schema: "User",
                table: "Rooms",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_CampusId",
                schema: "User",
                table: "Rooms",
                newName: "IX_Rooms_BuildingId");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "User",
                table: "Divisions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentId",
                schema: "User",
                table: "Divisions",
                column: "ParentId");

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
                name: "FK_Rooms_Campuses_BuildingId",
                schema: "User",
                table: "Rooms",
                column: "BuildingId",
                principalSchema: "User",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
