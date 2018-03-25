using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetCodeRepo : IRepo<BudgetCode>
    {
        BudgetCode GetBudgetCodeWithBudgetAmount(int? id);

        IEnumerable<BudgetCode> GetAllWithBudgetAmount();

        IEnumerable<BudgetCode> GetAllActiveBudgetCodes();
    }
}
