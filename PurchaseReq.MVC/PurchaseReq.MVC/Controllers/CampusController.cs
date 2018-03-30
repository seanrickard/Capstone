using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]/{id}")]
    public class CampusController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public CampusController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public async Task<IActionResult> Index(int id)
        {
            var campus = await _webApiCalls.GetCampusAsync(id);
            System.Console.WriteLine(campus.CampusName);
            var viewModel = new CampusViewModel
            {
                CampusName = campus.CampusName,
                Active = campus.Active,
                //StreetAddress = campus.Address.StreetAddress,
                //City = campus.Address.City,
                //State = campus.Address.State,
                //Zip = campus.Address.Zip
            };
            var list = new List<CampusViewModel>();
            list.Add(viewModel);
            
            return View(list);
        }

        public IActionResult AddCampus()
        {
            CampusWithAddress cmp = new CampusWithAddress();

            return View(cmp);
        }
    }
}