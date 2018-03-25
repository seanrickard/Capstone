using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetCodeRepo : IRepo<BudgetCode>
    {
<<<<<<< HEAD
        BudgetCode GetBudgetCodeWithBudgetAmount(int? id);

        IEnumerable<BudgetCode> GetAllWithBudgetAmount();

        IEnumerable<BudgetCode> GetAllActiveBudgetCodes();
=======
        IEnumerable<BudgetCode> GetAllBudgetCodes();
        BudgetCode GetBudgetCodeById(int budgetCodeId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
