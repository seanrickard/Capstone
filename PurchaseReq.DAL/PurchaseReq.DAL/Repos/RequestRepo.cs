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

        internal RequestWithVendor GetRecord(Request r, Item i, Vendor v)
        {

            var request = new RequestWithVendor
            {
                Id = r.Id,
                EstimatedTotal = r.EstimatedTotal,
                Chosen = r.Chosen,
                OrderId = r.OrderId,
                PaidCost = r.PaidCost,
                PaidTotal = r.PaidTotal,
                EstimatedCost = r.EstimatedCost,
                QuantityRequested = r.QuantityRequested,
                ItemName = i.ItemName,
                Description = i.Description,
                ItemId = i.Id,
            };

            if(r.ReasonChosen != null)
            {
                request.ReasonChosen = r.ReasonChosen;
            }

            if (r.TimeStamp != null)
            {
                request.TimeStamp = r.TimeStamp;
            }


            if (i != null)
            {
                request.VendorId = v.Id;
                request.VendorName = v.VendorName;
            }
            return request;
        }
    }
}
