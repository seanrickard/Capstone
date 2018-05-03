using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class ActualyFixAddBudgetCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop proc spAddBudgetCode");
            var sql = "create proc spAddBudgetCode(@Active as Bit, @BudgetCodeName as NVARCHAR(MAX), @DA as Int, @Type as Bit, @BudgetAmount as Decimal) " +
                " as " +
                " begin " +
                " Declare @budgetId int " +
                " " +
                " insert into [User].BudgetCodes (Active, BudgetCodeName, DA, [Type])" +
                " values (@Active, @BudgetCodeName, @DA, @Type) " +
                " Set @budgetId = ( Select Top 1" +
                " id " +
                " from [User].BudgetCodes " +
                " order by Id desc) " +
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
