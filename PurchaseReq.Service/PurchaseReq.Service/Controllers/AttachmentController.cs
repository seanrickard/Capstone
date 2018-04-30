using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AttachmentController : Controller
    {

        private readonly IAttachmentRepo _repo;

        public AttachmentController(IAttachmentRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetAll(int requestId)
        {
            var item = await _repo.GetAttachments(requestId);
            if(item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }

        [HttpPost("{requestId}")]
        public IActionResult Create(int requestId, IEnumerable<IFormFile> files)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var reader = new BinaryReader(formFile.OpenReadStream()))
                    {
                        byte[] file = reader.ReadBytes((int)formFile.Length);
                        Attachment newAttachment = new Attachment();
                        newAttachment.RequestId = requestId;
                        newAttachment.Content = file;
                        newAttachment.ContentType = formFile.ContentType;
                        newAttachment.FileName = formFile.FileName;
                        _repo.Add(newAttachment);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count(), size });
        }

        [HttpGet("{attachmentId}")]
        public IActionResult Get(int attachmentId)
        {
            var item = _repo.Find(attachmentId);

            if (item == null)
            {
                return BadRequest();
            }

            return Json(item);
        }

        [HttpPut("{attachmentId}")]
        public IActionResult Delete(int attachmentId, [FromBody] Attachment attachment)
        {
            var item = _repo.Find(attachmentId);

            if(item == null)
            {
                return BadRequest();
            }
            return Ok(_repo.Delete(item));
        }
    }
}
