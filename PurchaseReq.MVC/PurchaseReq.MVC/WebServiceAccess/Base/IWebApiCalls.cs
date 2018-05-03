using Microsoft.AspNetCore.Http;
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

        //EmployeeBudgetCodes
        Task<string> CreateBudgetCode(EmployeesBudgetCodes ebc);
        Task<string> UpdateBudgetCode(int id, EmployeesBudgetCodes ebc);
        Task<IList<EmployeeBudgetCodeViewModel>> GetEmployeesInBudgetCodeAsync(int id);
        Task<IList<EmployeeBudgetCodeViewModel>> GetAllEmployeesBudgetCodes(string id);
        Task<IList<EmployeeBudgetCodeViewModel>> GetEmployeesCurrentlyInBudgetCodeAsync(int id);

        //Campus
        Task<IList<CampusWithAddress>> GetCampusesAsync();
        Task<CampusWithAddress> GetCampusAsync(int id);
        Task<IList<RoomWithCampus>> GetRoomsByCampusAsync(int id);
        Task<IList<Room>> GetRoomsAsync();
        Task<IList<CampusWithAddress>> GetInactiveCampusesAsync();
        //Task<IList<PRWithRequest>> GetOrdersAsync();

        //Budget
        Task<IList<BudgetCodeWithAmount>> GetBudgetsAsync();
        Task<BudgetCodeWithAmount> GetBudgetAsync(int id);
        

        //Division
        Task<IList<DivisionWithSupervisor>> GetDivisionsAsync();
        Task<DivisionWithSupervisor> GetDivisionAsync(int id);
        Task<IList<DivisionWithSupervisor>> GetInActiveDivisionsAsync();

        //Department
        Task<IList<DepartmentWithDivision>> GetDepartmentsAsync();
        Task<DepartmentWithDivision> GetDepartmentAsync(int id);
        Task<IList<DepartmentWithDivision>> GetDepartmentsByDivison(int id);
        Task<IList<DepartmentWithDivision>> GetInactiveDepartmentsAsync();

        //Request
        Task<IList<RequestWithVendor>> GetRequestWithVendors();
        Task<RequestWithVendor> GetOneRequest(int id);
        Task<Item> GetOneItem(int id);

        //Order
        Task<PRWithRequest> GetNewOrder(string id);
        Task<IList<Category>> GetCategoriesAsync();
        Task<PRWithRequest> IncrementStatus(int id);
        Task<IList<PRWithRequest>> GetEmployeeOrderByTypeAsync(string id, string type);
        Task<IList<PRWithRequest>> GetOrderByTypeAsync(string type);
        Task<PRWithRequest> GetOrderAsync(int id);
        Task<IList<PRWithRequest>> GetOrdersAsync(string id);
        Task<IList<PRWithRequest>> GetPendingOrdersAsync(string id);
        Task<PRWithRequest> MoveToCFOStatus(int id);
        Task<PRWithRequest> CancelOrderAsync(int id);
        Task<PRWithRequest> MoveToDeniedStatus(int id);
        Task<IList<PRWithRequest>> GetDeniedBySupervisorAsync(string id);


        //Employee
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployees();
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployeeByDepartment(int id);
        Task<object> LoginEmployee(LogInViewModel logInViewModel);
        Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetInActiveEmployees();
        Task<EmployeeWithDepartmentAndRoomAndRole> GetEmployeeAsync(string id);
        Task<NotificationViewModel> GetNotification(string userId);
        Task<IList<Employee>> GetEmployeesAsEmployees();

        //Supervisor

        Task<IList<PRWithRequest>> GetSubmittedAsync(string id);

        //CFO
        Task<IList<PRWithRequest>> GetWaitingOnCFO();

        //Roles
        Task<IList<Employee>> GetSupervisors();
        

        //Approval
        Task<IList<Approval>> GetApprovals();

        //Attachment
        Task<RequestWithAttachmentsViewModel> GetAttachments(int requestId);
        Task AddAttachments(int requestId, IEnumerable<IFormFile> files);
        Task<Attachment> Download(int attachmentId);
        Task Delete(int attachmentId, Attachment attachment);


        //Dropdowns
        Task<List<SelectListItem>> GetDivisionsForDropDown();
        Task<List<SelectListItem>> GetSupervisorsForDropDown();
        Task<List<SelectListItem>> GetDepartmentsForDropDown();
        Task<List<SelectListItem>> GetRolesForDropdown();
        Task<List<SelectListItem>> GetRoomsForDropdown();
        Task<List<SelectListItem>> GetBudgetCodesForDropDown(string id);
        Task<List<SelectListItem>> GetCategoriesForDropDown();
        Task<List<SelectListItem>> GetEmployeesForDropDown();


    }
}
