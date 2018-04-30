using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Threading.Tasks;

namespace PurchaseReq.DAL.Repos
{
    public class AttachmentRepo : RepoBase<Attachment>, IAttachmentRepo
    {
        public async Task<RequestWithAttachmentsViewModel> GetAttachments(int requestId)
        {
            var request = await Context.Requests.Include(x => x.Attachments).Include(x => x.Item).FirstOrDefaultAsync(x => x.Id == requestId);
            return GetRecord(request);
        }

        internal AttachmentViewModel GetRecord(Attachment a) => new AttachmentViewModel
        {
            FileName = a.FileName,
            Id = a.Id,
            TimeStamp = a.TimeStamp
        };

        internal RequestWithAttachmentsViewModel GetRecord(Request r) => new RequestWithAttachmentsViewModel
        {
            Id = r.Id,
            Description = r.Item.Description,
            ItemName = r.Item.ItemName,
            TimeStamp = r.TimeStamp,
            Attachments = r.Attachments.ConvertAll(x => GetRecord(x))
        };


    }
}
