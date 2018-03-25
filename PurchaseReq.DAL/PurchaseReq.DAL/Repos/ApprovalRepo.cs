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
    public class ApprovalRepo : RepoBase<Approval>, IApprovalRepo
    {
        public ApprovalRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<Approval> GetAllApprovals() => Table.OrderBy(x => x.ApprovalName);
        public Approval GetApprovalById(int approvalId) => Table.FirstOrDefault(x => x.Id == approvalId);
    }



}
