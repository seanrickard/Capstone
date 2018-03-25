using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IApprovalRepo : IRepo<Approval>
    {
<<<<<<< HEAD
        Approval GetApprovalWithSupervisorApprovals(int? id);

        IEnumerable<Approval> GetAllWithSupervisorApprovals(int? id);
=======
        IEnumerable<Approval> GetAllApprovals();
        Approval GetApprovalById(int approvalId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
