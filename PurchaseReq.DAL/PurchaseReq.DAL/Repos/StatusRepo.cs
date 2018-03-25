using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class StatusRepo : RepoBase<Status>, IStatusRepo
    {
        public Status GetStatusWithOrders(int? id)
            => Table.Include(x => x.Orders).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Status> GetAllWithOrders()
            => Table.Include(x => x.Orders);

    }
}
