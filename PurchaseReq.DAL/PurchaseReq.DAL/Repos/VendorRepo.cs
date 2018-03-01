using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos
{
    public class VendorRepo : RepoBase<Vendor>, IVendorRepo
    {
        public VendorRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public VendorRepo()
        {

        }

        public Vendor GetOneWithRequests(int? id) => Table.Include(x => x.Requests).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Vendor> GetAllWithRequests() => Table.Include(x => x.Requests).ToList();
        public override IEnumerable<Vendor> GetAll() => Table.OrderBy(x => x.VendorName);
        public override IEnumerable<Vendor> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.VendorName), skip, take);

    }
}
