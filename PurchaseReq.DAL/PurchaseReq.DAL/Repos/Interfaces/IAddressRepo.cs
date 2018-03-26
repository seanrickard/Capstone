using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IAddressRepo : IRepo<Address>
    {
        Address GetAddressWithCampuses(int? id);

        Address GetAddressWithVendor(int? id);

        IEnumerable<Address> GetAllWithCampuses();

        IEnumerable<Address> GetAllWithVendor();
    }
}
