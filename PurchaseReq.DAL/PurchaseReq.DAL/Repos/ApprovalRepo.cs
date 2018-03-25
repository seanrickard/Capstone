using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
=======
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;
using System;
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class ApprovalRepo : RepoBase<Approval>, IApprovalRepo
    {
<<<<<<< HEAD
        public Approval GetApprovalWithSupervisorApprovals(int? id)
            => Table.Include(x => x.SupervisorApprovals).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Approval> GetAllWithSupervisorApprovals(int? id)
            => Table.Include(x => x.SupervisorApprovals);
=======
        public ApprovalRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<Approval> GetAllApprovals() => Table.OrderBy(x => x.ApprovalName);
        public Approval GetApprovalById(int approvalId) => Table.FirstOrDefault(x => x.Id == approvalId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }



}
