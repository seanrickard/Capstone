

using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace PurchaseReq.DAL.Repos
{
    public class BudgetCodeRepo : RepoBase<BudgetCode>, IBudgetCodeRepo
    {

        public BudgetCode GetBudgetCodeWithBudgetAmount(int? id)
            => Table.Include(x => x.BudgetAmounts).SingleOrDefault(x => x.Id == id);

        public IEnumerable<BudgetCode> GetAllWithBudgetAmount()
            => Table.Include(x => x.BudgetAmounts).ToList();

        public IEnumerable<BudgetCode> GetAllActiveBudgetCodes()
            => Table.Include(x => x.BudgetAmounts).Where(x => x.Active == true).ToList();

        public IEnumerable<BudgetCodeWithAmount> GetAllWithCurrentAmount()
            => Table.Include(x => x.BudgetAmounts).Select(item => GetRecord(item, item.BudgetAmounts.Last()));

        public BudgetCodeWithAmount GetBudgetCodeWithCurrentAmount(int id)
            => Table.Where(x => x.Id == id).Include(x => x.BudgetAmounts)
                    .Select(item => GetRecord(item, item.BudgetAmounts.Last())).SingleOrDefault();

        internal BudgetCodeWithAmount GetRecord(BudgetCode c, BudgetAmount p)
            => new BudgetCodeWithAmount()
            {
                Id = c.Id,
                Active = c.Active,
                BudgetCodeName = c.BudgetCodeName,
                DA = c.DA,
                TimeStamp = c.TimeStamp,
                Type = c.Type,
                BudgetAmountId = p.Id,
                TotalAmount = p.TotalAmount
            };


        public IEnumerable<BudgetCodeWithAmount> GetRangeWithCurrentAmounts(int skip, int take)
            => GetAllWithCurrentAmount().Skip(skip).Take(take);

        public IEnumerable<BudgetCodeWithAmount> GetActive(int skip, int take)
            => GetAllActiveBudgetCodes().Select(item => GetRecord(item, item.BudgetAmounts.Last())).Skip(skip).Take(take);
    }
}
