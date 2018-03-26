using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IApprovalRepo : IRepo<Approval>
    {

        Approval GetApprovalWithSupervisorApprovals(int? id);

        IEnumerable<Approval> GetAllWithSupervisorApprovals(int? id);
    }
}
