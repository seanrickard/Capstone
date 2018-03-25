using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ISupervisorApproval : IRepo<SupervisorApproval>
    {
        SupervisorApproval GetSupervisorApprovalWithApproval(int? id);

        IEnumerable<SupervisorApproval> GetAllWithSupervisorApprovals();
    }
}
