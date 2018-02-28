using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using PurchaseReq.Models.Entities;
using System.Text;

namespace PurchaseReq.DAL.Repos
{
    public class AttachmentRepo : RepoBase<Attachment>, IAttachmentRepo
    {
    }
}
