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
    public class StatusRepo : RepoBase<Status>, IStatusRepo
    {
        public StatusRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public StatusRepo()
        {

        }

        public Status GetOneWithOrders(int? id) => Table.Include(x => x.Orders).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Status> GetAllWithOrders() => Table.Include(x => x.Orders).ToList();
        public override IEnumerable<Status> GetAll() => Table.OrderBy(x => x.StatusName);
        public override IEnumerable<Status> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.StatusName), skip, take);
    }
}
