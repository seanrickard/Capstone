using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IRequestRepo : IRepo<Request>
    {
        Request GetRequestWithOrderAndAttachmentAndItemAndVendor(int? id);

        IEnumerable<Request> GetAllWithOrderAndAttachmentAndItemAndVendor();

        IEnumerable<Request> GetAllRequestForOrder(int orderId);

        IEnumerable<Request> GetAllChoosenForOrder(int orderId);
    }
}
