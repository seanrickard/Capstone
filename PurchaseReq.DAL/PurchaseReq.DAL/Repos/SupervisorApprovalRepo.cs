using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class SupervisorApprovalRepo : RepoBase<SupervisorApproval>, ISupervisorApproval
    {
        public IEnumerable<SupervisorApproval> Get()
        {
            return Table;
        }

        public SupervisorApproval Get(int id)
        {
            return Table.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<SupervisorApproval> GetForOrder(int orderId)
        {
            return Table.Where(x => x.OrderId == orderId);
        }
    }
}
