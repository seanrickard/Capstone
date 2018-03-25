using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IVendorRepo : IRepo<Vendor>
    {
        Vendor GetVendorWithRequest(int? id);

        IEnumerable<Vendor> GetAllWithRequest();

        Vendor GetVendorWithAddress(int? id);

        IEnumerable<Vendor> GetAllWithAddress();
    }
}
