using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class BudgetCodeRepo : RepoBase<BudgetCode>, IBudgetCodeRepo
    {
        public BudgetCode GetBudgetCodeWithBudgetAmount(int? id)
            => Table.Include(x => x.BudgetAmounts).SingleOrDefault(x => x.Id == id);

        public IEnumerable<BudgetCode> GetAllWithBudgetAmount()
            => Table.Include(x => x.BudgetAmounts);

        public IEnumerable<BudgetCode> GetAllActiveBudgetCodes()
            => Table.Include(x => x.BudgetAmounts).Where(x => x.Active == true);
    }
}
