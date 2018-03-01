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
    public class RequestRepo : RepoBase<Request>, IRequestRepo
    {
        public RequestRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public RequestRepo()
        {

        }

        public Request GetOneWithItem(int? id) => Table.Include(x => x.Item).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Request> GetAllWithItems() => Table.Include(x => x.Item).ToList();
        public Request GetOneWithAttachments(int? id) => Table.Include(x => x.Attachments).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Request> GetAllWithAttachments() => Table.Include(x => x.Attachments).ToList();
        public Request GetOneWithVendor(int? id) => Table.Include(x => x.Vendor).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Request> GetAllWithVendors() => Table.Include(x => x.Vendor).ToList();
        public Request GetOneWithOrder(int? id) => Table.Include(x => x.Order).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Request> GetAllWithOrders() => Table.Include(x => x.Order).ToList();

        public override IEnumerable<Request> GetAll() => Table.OrderBy(x => x.Id);
        public override IEnumerable<Request> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.Id), skip, take);

    }
}
