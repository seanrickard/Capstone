using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.Configuration;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class AttachmentController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public IWebServiceLocator Settings { get; }

        public AttachmentController(IWebApiCalls webApiCalls, IWebServiceLocator settings)
        {
            
            _webApiCalls = webApiCalls;
            Settings = settings;
        }

        [HttpGet("{requestId}")]
        public async Task<IActionResult> Index(int requestId)
        {
            var model = await _webApiCalls.GetAttachments(requestId);
            return View(model);
        }

        [HttpPost("{requestId}")]
        public async Task<IActionResult> AddAttachments(int requestId, IEnumerable<IFormFile> files)
        {
            using (var client = new HttpClient())
            {
                var ServiceAddress = Settings.ServiceAddress;

                foreach (var file in files)
                {
                    if (file.Length <= 0)
                        continue;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    using (var content = new MultipartFormDataContent())
                    {
                        content.Add(new StreamContent(file.OpenReadStream())
                        {
                            Headers =
                            {
                                ContentLength = file.Length,
                                ContentType = new MediaTypeHeaderValue(file.ContentType)
                            }
                        }, "files", fileName);
                        var response = await client.PostAsync($"{ServiceAddress}api/Attachment/Create/{requestId}", content);
                    }
                }
            }


            return RedirectToAction("Index", new { requestId });
        }

        [HttpGet("{attachmentId}")]
        public async Task<IActionResult> Delete(int attachmentId, AttachmentViewModel attachment)
        {
            var model = await _webApiCalls.Download(attachmentId);
            await _webApiCalls.Delete(attachmentId, model);
            return RedirectToAction("Index", new { model.RequestId });
        }

        [HttpGet("{attachmentId}")]
        public async Task<IActionResult> Download(int attachmentId)
        {
            var attachment = await _webApiCalls.Download(attachmentId);
            return File(attachment.Content, attachment.ContentType, attachment.FileName);
        }
    }
}
