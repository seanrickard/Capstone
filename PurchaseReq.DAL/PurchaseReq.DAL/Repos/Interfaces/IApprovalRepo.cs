using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IApprovalRepo : IRepo<Approval>
    {
        IEnumerable<Approval> GetAllApprovals();
        Approval GetApprovalById(int approvalId);
    }
}
