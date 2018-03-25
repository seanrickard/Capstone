using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class OrderRepo : RepoBase<Order>, IOrderRepo
    {
        public Order GetOrderWithRequestAndSupervisorApprovalAndStatusAndCategory(int? id)
            => Table.Include(x => x.Requests).Include(x => x.Status).Include(x => x.Category)
                .SingleOrDefault(x => x.Id == id);

        public IEnumerable<Order> GetAllWithRequestAndSupervisorApprovalAndStatusAndCategory()
            => Table.Include(x => x.Requests).Include(x => x.Status).Include(x => x.Category);

        public IEnumerable<Order> GetAllOrdersForUser(string userId)
            => Table.Include(x => x.Requests).Include(x => x.Status).Include(x => x.Category)
                .Where(x => x.EmployeeId == userId);

        public IEnumerable<Order> GetAllOrdersWaitingForSupervisorApproval(string supervisorId)
            => Table.Include(x => x.Requests).Include(x => x.Status).Include(x => x.Category)
                .Where(x => x.Employee.Department.Division.SupervisorId == supervisorId &&
                            x.Status.StatusName == "Waiting For Supervisor Approval");

        public IEnumerable<Order> GetAllOrdersWaitingForCfoApproval()
            => Table.Include(x => x.Requests).Include(x => x.Status).Include(x => x.Category)
                .Where(x => x.Status.StatusName == "Waiting for CFO Approval");
    }
}
