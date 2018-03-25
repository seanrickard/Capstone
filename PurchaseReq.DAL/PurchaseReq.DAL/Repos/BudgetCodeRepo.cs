using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PurchaseReq.DAL.Repos
{
    public class BudgetCodeRepo : RepoBase<BudgetCode>, IBudgetCodeRepo
    {
        public BudgetCodeRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<BudgetCode> GetAllBudgetCodes() => Table.Include(x => x.BudgetCodeName);
        public BudgetCode GetBudgetCodeById(int budgetCodeId) => Table.FirstOrDefault(x => x.Id == budgetCodeId);

    }
}
