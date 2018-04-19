using Microsoft.AspNetCore.Mvc.Rendering;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<string> CreateAsync<T>(T input);
        Task<string> UpdateAsync<T>(int id, T input);

        //Campus
        Task<IList<CampusWithAddress>> GetCampusesAsync();
        Task<CampusWithAddress> GetCampusAsync(int id);
        Task<IList<RoomWithCampus>> GetRoomsByCampusAsync(int id);
        Task<IList<Room>> GetRoomsAsync();
        //Task<IList<PRWithRequest>> GetOrdersAsync();

        //Budget
        Task<IList<BudgetCodeWithAmount>> GetBudgetsAsync();
        Task<BudgetCodeWithAmount> GetBudgetAsync(int id);

        //Division
        Task<IList<DivisionWithSupervisor>> GetDivisionsAsync();
        Task<DivisionWithSupervisor> GetDivisionAsync(int id);

        //Department
        Task<IList<DepartmentWithDivision>> GetDepartmentsAsync();
        Task<DepartmentWithDivision> GetDepartmentAsync(int id);
        Task<IList<DepartmentWithDivision>> GetDepartmentsByDivison(int id);

        //Request
        Task<IList<RequestWithVendor>> GetRequestWithVendors();

        //Order
        Task<PRWithRequest> GetNewOrder(string id);
        Task<IList<Category>> GetCategoriesAsync();
        Task<PRWithRequest> IncrementStatus(int id);
        Task<PRWithRequest> GetOrderAsync(int id);
        Task<IList<PRWithRequest>> GetOrdersAsync(string id);
        Task<IList<PRWithRequest>> GetPendingOrdersAsync(string id);
        Task<PRWithRequest> MoveToCFOStatus(int id);


        //Employee
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployees();
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployeeByDepartment(int id);
        Task<object> LoginEmployee(LogInViewModel logInViewModel);

        //Supervisor

        Task<IList<PRWithRequest>> GetSubmittedAsync(string id);

        //Roles
        Task<IList<Employee>> GetSupervisors();

        //Approval
        Task<IList<Approval>> GetApprovals();



        //Dropdowns
        Task<List<SelectListItem>> GetDivisionsForDropDown();
        Task<List<SelectListItem>> GetSupervisorsForDropDown();
        Task<List<SelectListItem>> GetDepartmentsForDropDown();
        Task<List<SelectListItem>> GetRolesForDropdown();
        Task<List<SelectListItem>> GetRoomsForDropdown();
        Task<List<SelectListItem>> GetBudgetCodesForDropDown();
        Task<List<SelectListItem>> GetCategoriesForDropDown();


    }
}
