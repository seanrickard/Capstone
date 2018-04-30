using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Threading.Tasks;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IAttachmentRepo : IRepo<Attachment>
    {
        Task<RequestWithAttachmentsViewModel> GetAttachments(int requestId);
    }
}
