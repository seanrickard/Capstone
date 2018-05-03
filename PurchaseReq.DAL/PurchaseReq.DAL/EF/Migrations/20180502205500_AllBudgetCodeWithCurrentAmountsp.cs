using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class AllBudgetCodeWithCurrentAmountsp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = "Create Proc spAllBudgetCodeWithCurrentAmount " +
                " As " +
                " Begin " +
                " Select BC.ID, BC.Active, BC.BudgetCodeName, BC.[TimeStamp], BC.[Type], BA.Id as BudgetAmountId, ba.TotalAmount " +
                " from [User].BudgetCodes as BC " +
                " inner join [User].BudgetAmounts as BA on BC.Id = BA.BudgetCodeId " +
                " and BA.Id = " +
                " (Select Max(Id) " +
                " from [User].BudgetAmounts as TopBA " +
                " where TopBA.BudgetCodeId = BC.Id " +
                " ) " +
                " End ";
            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop Proc spAllBudgetCodeWithCurrentAmount");
        }
    }
}
