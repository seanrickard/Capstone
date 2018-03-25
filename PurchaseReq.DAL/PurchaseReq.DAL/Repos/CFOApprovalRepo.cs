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
    public class CFOApprovalRepo : RepoBase<CFOApproval>, ICFOApprovalRepo
    {
        public CFOApprovalRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<CFOApproval> GetAllCFOApprovals() => Table.OrderBy(x => x.CFOId);

        public CFOApproval GetCFOApprovalById(int CFOApprovalId) => Table.FirstOrDefault(x => x.Id == CFOApprovalId);
        
    }
}
