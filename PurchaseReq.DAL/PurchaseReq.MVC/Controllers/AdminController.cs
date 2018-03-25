using Microsoft.AspNetCore.Mvc;

namespace PurchaseReq.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult UserManagement() => View();

        public IActionResult AddUser() => View();

        public IActionResult CategoryManagement() => View();

        public IActionResult AddCategory() => View();

        public IActionResult DivisionManagement() => View();

        public IActionResult AddDivision() => View();

        public IActionResult DepartmentManagement() => View();

        public IActionResult AddDepartment() => View();

        public IActionResult CampusManagement() => View();


    }
}