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
    public class AttachmentRepo : RepoBase<Attachment>, IAttachmentRepo
    {
        public AttachmentRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<Attachment> GetAllAttachments() => Table.OrderBy(x => x.Id);


        public Attachment GetAttachmentById(int attachmentId) => Table.FirstOrDefault(x => x.Id == attachmentId);
        
    }
}
