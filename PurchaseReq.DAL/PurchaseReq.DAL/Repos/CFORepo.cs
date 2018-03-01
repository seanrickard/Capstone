using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos
{
    public class CFORepo : RepoBase<CFO>, ICFORepo
    {
        public CFORepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public CFORepo()
        {

        }

        public CFO GetOneWithApprovals(int? id) => Table.Include(x => x.CFOApprovals).SingleOrDefault(x => x.Id == id);
        public IEnumerable<CFO> GetAllWithApprovals() => Table.Include(x => x.CFOApprovals).ToList();
        public CFO GetOneWithc(int? id) => Table.Include(x => x.DateAdded).SingleOrDefault(x => x.Id == id);
        public IEnumerable<CFO> GetAllWithDateAdded() => Table.Include(x => x.DateAdded).ToList();
        public override IEnumerable<CFO> GetAll() => Table.OrderBy(x => x.Employee);
        public override IEnumerable<CFO> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.Employee), skip, take);
    }
}
