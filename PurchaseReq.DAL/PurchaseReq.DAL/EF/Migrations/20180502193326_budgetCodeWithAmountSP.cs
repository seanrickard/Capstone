using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class budgetCodeWithAmountSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = "Create Proc spBudgetCodeWithCurrentAmount (@budgetCodeId as int) " +
                " As " +
                " Begin " +
                " Select TOP 1 BC.ID, BC.Active, BC.BudgetCodeName, BC.[TimeStamp], BC.[Type], BA.Id as BudgetAmountId, ba.TotalAmount " +
                " from [User].BudgetCodes as BC, [User].BudgetAmounts as BA " +
                " where ba.BudgetCodeId = @budgetCodeId and " +
                " BC.Id = @budgetCodeId " +
                " order by BA.Id desc " +
                " End ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop proc spBudgetCodeWithCurrentAmount");
        }
    }
}
