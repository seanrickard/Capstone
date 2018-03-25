using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetAmountRepo : IRepo<BudgetAmount>
    {
<<<<<<< HEAD:PurchaseReq.DAL/PurchaseReq.DAL/Repos/Interfaces/IBudgetAmountRepo.cs
        BudgetAmount GetBudgetCodesCurrentBudgetAmount(int id);
=======
        IEnumerable<CFO> GetAllCFOs();
        CFO GetCFOById(int CFOId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7:PurchaseReq.DAL/PurchaseReq.DAL/Repos/Interfaces/ICFORepo.cs
    }
}
