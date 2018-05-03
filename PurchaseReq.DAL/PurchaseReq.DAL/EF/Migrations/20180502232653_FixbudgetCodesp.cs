using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class FixbudgetCodesp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = "create proc spAddBudgetCode(@Active as Bit, @BudgetCodeName as NVARCHAR(MAX), @DA as Int, @Type as Bit, @BudgetAmount as Decimal) " +
                " as " +
                " begin " +
                " Declare @budgetId int " +
                " " +
                " insert into [User].BudgetCodes (Active, BudgetCodeName, DA, [Type])" +
                " values (@Active, @BudgetCodeName, @DA, @Type) " +
                " Select @budgetId = " +
                " id " +
                " from [User].BudgetCodes " +
                " order by Id desc " +
                " insert into [User].BudgetAmounts (BudgetCodeId, TotalAmount) " +
                " values (@budgetId, @BudgetAmount); " +
                " end ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop proc spAddBudgetCode");
        }
    }
}
