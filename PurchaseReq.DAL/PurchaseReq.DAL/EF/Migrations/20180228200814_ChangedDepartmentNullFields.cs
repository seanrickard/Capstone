﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class ChangedDepartmentNullFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                schema: "User",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                schema: "User",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
