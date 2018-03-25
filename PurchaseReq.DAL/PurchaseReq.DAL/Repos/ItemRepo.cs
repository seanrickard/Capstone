using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class ItemRepo : RepoBase<Item>, IItemRepo
    {
        public Item GetItemWithRequest(int? id)
            => Table.Include(x => x.Requests).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Item> GetAllWithRequest()
            => Table.Include(x => x.Requests);
    }
}
