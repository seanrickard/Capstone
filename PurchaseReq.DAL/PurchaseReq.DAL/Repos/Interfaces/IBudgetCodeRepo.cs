using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetCodeRepo : IRepo<BudgetCode>
    {

        BudgetCode GetBudgetCodeWithBudgetAmount(int? id);

        IEnumerable<BudgetCode> GetAllWithBudgetAmount();

        IEnumerable<BudgetCode> GetAllActiveBudgetCodes();

        IEnumerable<BudgetCodeWithAmount> GetRangeWithCurrentAmounts(int skip, int take);

        IEnumerable<BudgetCodeWithAmount> GetActive(int skip, int take);

        IEnumerable<BudgetCodeWithAmount> GetAllWithCurrentAmount();

        BudgetCodeWithAmount GetBudgetCodeWithCurrentAmount(int id);
    }
}
