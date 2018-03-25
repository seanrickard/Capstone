using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
<<<<<<< HEAD
=======
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7

namespace PurchaseReq.DAL.Repos
{
    public class AttachmentRepo : RepoBase<Attachment>, IAttachmentRepo
    {
<<<<<<< HEAD

=======
        public AttachmentRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<Attachment> GetAllAttachments() => Table.OrderBy(x => x.Id);


        public Attachment GetAttachmentById(int attachmentId) => Table.FirstOrDefault(x => x.Id == attachmentId);
        
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
