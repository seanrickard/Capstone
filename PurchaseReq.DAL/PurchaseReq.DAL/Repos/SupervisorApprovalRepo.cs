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
        public SupervisorApproval GetSupervisorApprovalWithApproval(int? id)
            => Table.Include(x => x.Approval).FirstOrDefault(x => x.Id == id);

        public IEnumerable<SupervisorApproval> GetAllWithSupervisorApprovals()
            => Table.Include(x => x.Approval);
    }
}
