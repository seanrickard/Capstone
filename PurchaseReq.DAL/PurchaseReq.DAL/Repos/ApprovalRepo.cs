using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class ApprovalRepo : RepoBase<Approval>, IApprovalRepo
    {

        public Approval GetApprovalWithSupervisorApprovals(int? id)
            => Table.Include(x => x.SupervisorApprovals).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Approval> GetAllWithSupervisorApprovals(int? id)
            => Table.Include(x => x.SupervisorApprovals);

    }
}
