using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class RequestRepo : RepoBase<Request>, IRequestRepo
    {
        public Request GetRequestWithOrderAndAttachmentAndItemAndVendor(int? id)
            => Table.Include(x => x.Order).Include(x => x.Attachments)
                .Include(x => x.Item).Include(x => x.Vendor)
                .SingleOrDefault(x => x.Id == id);

        public IEnumerable<Request> GetAllWithOrderAndAttachmentAndItemAndVendor()
            => Table.Include(x => x.Order).Include(x => x.Attachments)
                .Include(x => x.Item).Include(x => x.Vendor).ToList();

        public IEnumerable<Request> GetAllRequestForOrder(int orderId)
            => Table.Include(x => x.Order).Include(x => x.Attachments)
                .Include(x => x.Item).Include(x => x.Vendor)
                .Where(x => x.OrderId == orderId).ToList();

        public IEnumerable<Request> GetAllChoosenForOrder(int orderId)
            => Table.Include(x => x.Order).Include(x => x.Attachments)
                .Include(x => x.Item).Include(x => x.Vendor)
                .Where(x => x.OrderId == orderId && x.Chosen == true).ToList();
    }
}
