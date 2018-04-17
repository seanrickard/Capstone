using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetCodeRepo : IRepo<BudgetCode>
    {

        BudgetCodeWithAmount GetBudgetCodeWithBudgetAmount(int? id);

        IEnumerable<BudgetCodeWithAmount> GetAllWithBudgetAmount();

        IEnumerable<BudgetCodeWithAmount> GetAllActiveBudgetCodes();

        IEnumerable<BudgetCodeWithAmount> GetRangeWithCurrentAmounts(int skip, int take);

        IEnumerable<BudgetCodeWithAmount> GetActive(int skip, int take);

        IEnumerable<BudgetCodeWithAmount> GetAllWithCurrentAmount();

        BudgetCodeWithAmount GetBudgetCodeWithCurrentAmount(int id);
    }
}
