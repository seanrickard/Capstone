using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetAmountRepo : IRepo<BudgetAmount>
    {

        BudgetAmount GetBudgetCodesCurrentBudgetAmount(int id);

       

    }
}
