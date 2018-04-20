using Microsoft.AspNetCore.Mvc;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class CampusController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public CampusController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IList<CampusWithAddress> campuses = await _webApiCalls.GetCampusesAsync();
            ViewBag.Active = true;

            return View(campuses);
        }

        [HttpGet]
        public async Task<IActionResult> InActive()
        {
            //GetInactive Campuses
            IList<CampusWithAddress> campuses = await _webApiCalls.GetInactiveCampusesAsync();
            ViewBag.Active = false;

            return View("Index", campuses);
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

        [HttpGet]
        public async Task<IActionResult> EditCampus(int campusId)
        {
            var campus = await _webApiCalls.GetCampusAsync(campusId);
            return View(campus);
        }

        [HttpPost]
        public async Task<IActionResult> EditCampus(CampusWithAddress model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Campus = new Campus
            {
                Id = model.Id,
                Active = model.Active,
                Address = new Address { Zip = model.Zip, City = model.City, StreetAddress = model.StreetAddress, State = model.State },
                CampusName = model.CampusName,
                TimeStamp = model.TimeStamp
            };

            var result = await _webApiCalls.UpdateAsync(Campus.Id, Campus);

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