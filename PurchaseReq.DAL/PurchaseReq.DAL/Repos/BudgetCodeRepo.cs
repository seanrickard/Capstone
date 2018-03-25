using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using PurchaseReq.DAL.EF;
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using System.Text;

>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7

namespace PurchaseReq.DAL.Repos
{
    public class BudgetCodeRepo : RepoBase<BudgetCode>, IBudgetCodeRepo
    {
<<<<<<< HEAD
        public BudgetCode GetBudgetCodeWithBudgetAmount(int? id)
            => Table.Include(x => x.BudgetAmounts).SingleOrDefault(x => x.Id == id);

        public IEnumerable<BudgetCode> GetAllWithBudgetAmount()
            => Table.Include(x => x.BudgetAmounts);

        public IEnumerable<BudgetCode> GetAllActiveBudgetCodes()
            => Table.Include(x => x.BudgetAmounts).Where(x => x.Active == true);
=======
        public BudgetCodeRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<BudgetCode> GetAllBudgetCodes() => Table.Include(x => x.BudgetCodeName);
        public BudgetCode GetBudgetCodeById(int budgetCodeId) => Table.FirstOrDefault(x => x.Id == budgetCodeId);

>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
