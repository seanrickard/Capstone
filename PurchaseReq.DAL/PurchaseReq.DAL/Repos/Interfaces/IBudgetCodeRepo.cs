using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IBudgetCodeRepo : IRepo<BudgetCode>
    {
        IEnumerable<BudgetCode> GetAllBudgetCodes();
        BudgetCode GetBudgetCodeById(int budgetCodeId);
    }
}
