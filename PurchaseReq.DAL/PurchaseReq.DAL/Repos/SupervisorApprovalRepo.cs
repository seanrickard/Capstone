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
    public class SupervisorApprovalRepo : RepoBase<SupervisorApproval>, ISupervisorApprovalRepo
    {
        public SupervisorApprovalRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public SupervisorApprovalRepo()
        {

        }

        public SupervisorApproval GetOneWithEmployees(int? id) => Table.Include(x => x.Employee).SingleOrDefault(x => x.Id == id);
        public IEnumerable<SupervisorApproval> GetAllWithEmployees() => Table.Include(x => x.Employee).ToList();
        public SupervisorApproval GetOneWithOrders(int? id) => Table.Include(x => x.Order).SingleOrDefault(x => x.Id == id);
        public IEnumerable<SupervisorApproval> GetAllWithOrders() => Table.Include(x => x.Order).ToList();
        public override IEnumerable<SupervisorApproval> GetAll() => Table.OrderBy(x => x.SupervisorId);
        public override IEnumerable<SupervisorApproval> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.SupervisorId), skip, take);
    }
}
