using Microsoft.AspNetCore.Mvc.Rendering;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {

        //Campus
        Task<IList<CampusWithAddress>> GetCampusesAsync();
        Task<string> CreateCampusAsync(Campus campus);
        Task<CampusWithAddress> GetCampusAsync(int id);
        Task<IList<RoomWithCampus>> GetRoomsByCampusAsync(int id);
        Task<IList<Room>> GetRoomsAsync();

        //Budget
        Task<IList<BudgetCodeWithAmount>> GetBudgetsAsync();
        Task<BudgetCodeWithAmount> GetBudgetAsync(int id);

        //Division
        Task<IList<DivisionWithSupervisor>> GetDivisionsAsync();
        Task<DivisionWithSupervisor> GetDivisionAsync(int id);
        Task<string> CreateDivisionAsync(Division division);

        Task<string> UpdateDivision(int id, Division division);

        //Department
        Task<IList<DepartmentWithDivision>> GetDepartmentsAsync();
        Task<DepartmentWithDivision> GetDepartmentAsync(int id);
        Task<IList<DepartmentWithDivision>> GetDepartmentsByDivison(int id);
        Task<string> CreateDepartmentAsync(Department department);
        Task<string> UpdateDepartment(int id, Department department);

        //Request
        Task<IList<RequestWithVendor>> GetRequestWithVendors();

        //Employee
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployees();
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployeeByDepartment(int id);
        Task<object> LoginEmployee(LogInViewModel logInViewModel);

        //Roles
      //  Task<IList<Employee>> GetSupervisors();
        

        //Dropdowns
        Task<List<SelectListItem>> GetDivisionsForDropDown();
        Task<List<SelectListItem>> GetSupervisorsForDropDown();
        Task<List<SelectListItem>> GetDepartmentsForDropDown();
        Task<List<SelectListItem>> GetRolesForDropdown();
        Task<List<SelectListItem>> GetRoomsForDropdown();


    }
}
