using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class addBudgetCodesp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = "create proc spAddBudgetCode(@Active as Bit, @BudgetCodeName as NVARCHAR(MAX), @DA as Int, @Type as Bit) " +
                " as " +
                " begin " +
                " insert into [User].BudgetCodes (Active, BudgetCodeName, DA, [Type])" +
                " values (@Active, @BudgetCodeName, @DA, @Type) " +
                " end ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop proc spAddBudgetCode");
        }
    }
}
