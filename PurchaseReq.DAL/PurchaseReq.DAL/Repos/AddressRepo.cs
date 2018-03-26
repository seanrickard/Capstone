using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class AddressRepo : RepoBase<Address>, IAddressRepo
    {
        public Address GetAddressWithCampuses(int? id)
            => Table.Include(x => x.Campuses).FirstOrDefault(x => x.Id == id);


        public Address GetAddressWithVendor(int? id)
            => Table.Include(x => x.Vendors).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Address> GetAllWithCampuses()
            => Table.Include(x => x.Campuses);

        public IEnumerable<Address> GetAllWithVendor()
            => Table.Include(x => x.Vendors);

    }
}
