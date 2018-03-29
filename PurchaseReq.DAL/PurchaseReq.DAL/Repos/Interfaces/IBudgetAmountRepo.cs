using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetAmountRepo : IRepo<BudgetAmount>
    {

        BudgetAmount GetBudgetCodesCurrentBudgetAmount(int id);

        IEnumerable<BudgetAmount> GetBudgetAmountsForBudgetCode(int id);

    }
}
