using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
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
            IList<CampusWithAddress> campuses = await _webApiCalls.GetCampusesAsync();

            return View(campuses);
        }

        public IActionResult AddCampus()
        {
            CampusWithAddress cmp = new CampusWithAddress();

            return View(cmp);
        }


        [HttpPost]
        public async Task<IActionResult> AddCampus(CampusWithAddress cmp)
        {
            if (!ModelState.IsValid)
            {
                return View(cmp);
            }
            var campus = new Campus()
            {
                CampusName = cmp.CampusName,

                Address = new Address { StreetAddress = cmp.StreetAddress, City = cmp.City, State = cmp.State, Zip = cmp.Zip }

            };

            var result = await _webApiCalls.CreateAsync(campus);



            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Rooms(int id)
        {
            IList<RoomWithCampus> rooms;
            rooms = await _webApiCalls.GetRoomsByCampusAsync(id);


            return View(rooms);
        }
    }
}