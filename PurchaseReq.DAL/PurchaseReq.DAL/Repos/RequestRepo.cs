using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class RequestRepo : RepoBase<Request>, IRequestRepo
    {

        internal IEnumerable<Request> QueryAll()
        {
            return Table.Include(x => x.Vendor).Include(x => x.Item);
        }

        public new IEnumerable<RequestWithVendor> GetAll()
        {
            return QueryAll()
                        .Select(item => GetRecord(item, item.Item, item.Vendor));
        }

        public IEnumerable<RequestWithVendor> GetAllChoosenForOrder(int orderId)
        {
            return QueryAll().Where(x => x.OrderId == orderId && x.Chosen == true)
                        .Select(item => GetRecord(item, item.Item, item.Vendor));
        }

        public IEnumerable<RequestWithVendor> GetAllForOrder(int orderId)
        {
            return QueryAll().Where(x => x.OrderId == orderId)
                        .Select(item => GetRecord(item, item.Item, item.Vendor));
        }

        public RequestWithVendor GetRequest(int? id)
        {
            return QueryAll()
                        .Select(item => GetRecord(item, item.Item, item.Vendor))
                        .SingleOrDefault(x => x.Id == id);
        }

        internal RequestWithVendor GetRecord(Request r, Item i, Vendor v) => new RequestWithVendor
        {
            Id = r.Id,
            TimeStamp = r.TimeStamp,
            EstimatedTotal = r.EstimatedTotal,
            Chosen = r.Chosen,
            OrderId = r.OrderId,
            PaidCost = r.PaidCost,
            PaidTotal = r.PaidTotal,
            ReasonChosen = r.ReasonChosen,
            EstimatedCost = r.EstimatedCost,
            QuantityRequested = r.QuantityRequested,

            ItemName = i.ItemName,
            Description = i.Description,
            ItemId = i.Id,

            VendorId = v.Id,
            VendorName = v.VendorName,
        };
    }
}
