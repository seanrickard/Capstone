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
    public class OrderRepo : RepoBase<Order>, IOrderRepo
    {
        public OrderRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public OrderRepo()
        {

        }

        public Order GetOneWithEmployee(int? id) => Table.Include(x => x.Employee).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithEmployees() => Table.Include(x => x.Employee).ToList();
        public Order GetOneWithCFOApproval(int? id) => Table.Include(x => x.CFOApproval).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithCFOApprovals() => Table.Include(x => x.CFOApproval).ToList();
        public Order GetOneWithSupervisorApproval(int? id) => Table.Include(x => x.SupervisorApproval).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithSupervisorApprovals() => Table.Include(x => x.SupervisorApproval).ToList();
        public Order GetOneWithRequest(int? id) => Table.Include(x => x.Requests).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithRequests() => Table.Include(x => x.Requests).ToList();
        public Order GetOneWithStateContract(int? id) => Table.Include(x => x.StateContract).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithStateContracts() => Table.Include(x => x.StateContract).ToList();
        public Order GetOneWithDateOrdered(int? id) => Table.Include(x => x.DateOrdered).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithDateOrdered() => Table.Include(x => x.DateOrdered).ToList();
        public Order GetOneWithDateMade(int? id) => Table.Include(x => x.DateMade).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Order> GetAllWithDateMade() => Table.Include(x => x.DateMade).ToList();

        // Not sure what GetAll and GetRange should be ordered by.  Should probably implement method to get range of dates
        public override IEnumerable<Order> GetAll() => Table.OrderBy(x => x.Ordered);
        public override IEnumerable<Order> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.Ordered), skip, take);


    }
}
