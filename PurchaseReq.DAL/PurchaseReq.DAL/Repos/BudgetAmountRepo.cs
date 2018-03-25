using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class BudgetAmountRepo : RepoBase<BudgetAmount>, IBudgetAmountRepo
    {
        public BudgetAmount GetBudgetCodesCurrentBudgetAmount(int id)
            => Table.Last(x => x.BudgetCodeId == id);
    }
}
