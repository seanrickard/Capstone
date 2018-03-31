using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    public class CampusController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public CampusController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public async Task<IActionResult> Index()
        {
            IList<CampusWithAddress> campuses;
            campuses = await _webApiCalls.GetCampusesAsync();
            
           
            

            return View(campuses);
        }

        public IActionResult AddCampus()
        {
            CampusWithAddress cmp = new CampusWithAddress();

            return View(cmp);
        }

        public async Task<IActionResult> Rooms(int id)
        {
            IList<RoomWithCampus> rooms;
            rooms = await _webApiCalls.GetRoomsByCampusAsync(id);

            return View();
        }
    }
}