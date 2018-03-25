using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IItemRepo : IRepo<Item>
    {
        Item GetItemWithRequest(int? id);

        IEnumerable<Item> GetAllWithRequest();
    }
}
