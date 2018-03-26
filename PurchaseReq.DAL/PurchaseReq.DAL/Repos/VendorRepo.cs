using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class VendorRepo : RepoBase<Vendor>, IVendorRepo
    {
        public Vendor GetVendorWithRequest(int? id)
            => Table.Include(x => x.Requests).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Vendor> GetAllWithRequest()
            => Table.Include(x => x.Requests).ToList();

        public Vendor GetVendorWithAddress(int? id)
            => Table.Include(x => x.Address).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Vendor> GetAllWithAddress()
            => Table.Include(x => x.Address).ToList();
    }
}
