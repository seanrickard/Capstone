using System;
using System.Collections.Generic;
using System.Text;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IAttachmentRepo : IRepo<Attachment>
    {
<<<<<<< HEAD

=======
        IEnumerable<Attachment> GetAllAttachments();
        Attachment GetAttachmentById(int attachmentId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
