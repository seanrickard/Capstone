
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using PurchaseReq.MVC.Configuration;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess
{
    public class WebApiCalls : WebApiCallsBase, IWebApiCalls
    {    
        public WebApiCalls(IWebServiceLocator settings ) : base(settings)
        {

        }

        public async Task<string> CreateAsync<T>(T input)
        {
            var json = JsonConvert.SerializeObject(input);
            int idx = input.ToString().LastIndexOf('.');
            string type = input.ToString().Remove(0, idx + 1);
            return await SubmitPostRequestAsync(BaseUri + type + "/Create/", json);
        }

        public async Task<string> UpdateAsync<T>(int id, T input)
        {
            var json = JsonConvert.SerializeObject(input);
            int idx = input.ToString().LastIndexOf('.');
            string type = input.ToString().Remove(0, idx + 1);
            return await SubmitPutRequestAsync(BaseUri + type + "/Update/" + id + "/", json);
        }

        //EmployeeBudgetCodes
        public async Task<string> CreateBudgetCode(EmployeesBudgetCodes ebc)
        {
            var json = JsonConvert.SerializeObject(ebc);
            return await SubmitPostRequestAsync(CreateEmployeeBudgetCodeUri, json);

        }

        public async Task<string> UpdateBudgetCode(int id, EmployeesBudgetCodes ebc)
        {
            var json = JsonConvert.SerializeObject(ebc);
            return await SubmitPutRequestAsync(UpdateEmployeeBudgetCodeUri + id, json);
        }

        public async Task<IList<EmployeeBudgetCodeViewModel>> GetEmployeesInBudgetCodeAsync(int id)
        {
            return await GetItemListAsync<EmployeeBudgetCodeViewModel>($"{BudgetCodeWithEmployeesUri}{id}");
        }

        public async Task<IList<EmployeeBudgetCodeViewModel>> GetAllEmployeesBudgetCodes(string id)
        {
            return await GetItemListAsync<EmployeeBudgetCodeViewModel>($"{BudgetCodesForEmployeesUri}{id}");
        }

        public async Task<IList<EmployeeBudgetCodeViewModel>> GetEmployeesCurrentlyInBudgetCodeAsync(int id)
        {
            return await GetItemListAsync<EmployeeBudgetCodeViewModel>($"{ActiveBudgetCodesForEmployeesUri}{id}");
        }


        //Campus
        public async Task<IList<CampusWithAddress>> GetCampusesAsync()
        {
            return await GetItemListAsync<CampusWithAddress>(CampusWithAddressBaseUri);
        }

        public async Task<CampusWithAddress> GetCampusAsync(int id)
        {
            return await GetItemAsync<CampusWithAddress>($"{CampusWithAddressBaseUri}{id}");
        }

        public async Task<IList<RoomWithCampus>> GetRoomsByCampusAsync(int id)
        {
            return await GetItemListAsync<RoomWithCampus>($"{RoomsByCampusBaseUri}{id}");
        }

        public async Task<IList<Room>> GetRoomsAsync()
        {
            return await GetItemListAsync<Room>($"{GetRoomsBaseUri}");
        }

        public async Task<IList<CampusWithAddress>> GetInactiveCampusesAsync()
        {
            return await GetItemListAsync<CampusWithAddress>($"{GetInactiveCampusesUri}");
        }

        //Budget
        public async Task<IList<BudgetCodeWithAmount>> GetBudgetsAsync()
        {
            return await GetItemListAsync<BudgetCodeWithAmount>(BudgetCodeWithAmountBaseUri);
        }

        public async Task<BudgetCodeWithAmount> GetBudgetAsync(int id)
        {
            return await GetItemAsync<BudgetCodeWithAmount>($"{BudgetCodeWithAmountBaseUri}{id}");
        }

      

        //Division
        public async Task<IList<DivisionWithSupervisor>> GetDivisionsAsync()
        {
            return await GetItemListAsync<DivisionWithSupervisor>(DivisionWithSupervisorBaseUri);
        }

        public async Task<DivisionWithSupervisor> GetDivisionAsync(int id)
        {
            return await GetItemAsync<DivisionWithSupervisor>($"{DivisionWithSupervisorBaseUri}{id}");
        }

        public async Task<IList<DivisionWithSupervisor>> GetInActiveDivisionsAsync()
        {
            return await GetItemListAsync<DivisionWithSupervisor>(InActiveDivisionWithSupervisorBaseUri);
        }

       

        //Department
        public async Task<IList<DepartmentWithDivision>> GetDepartmentsAsync()
        {
            return await GetItemListAsync<DepartmentWithDivision>(DepartmentWithDivisionBaseUri);
        }

        public async Task<DepartmentWithDivision> GetDepartmentAsync(int id)
        {
            return await GetItemAsync<DepartmentWithDivision>($"{DepartmentWithDivisionBaseUri}{id}");
        }

        public async Task<IList<DepartmentWithDivision>> GetDepartmentsByDivison(int id)
        {
            return await GetItemListAsync<DepartmentWithDivision>($"{DepartmentByDivisionBaseUri}{id}");
        }

        public async Task<IList<DepartmentWithDivision>> GetInactiveDepartmentsAsync()
        {
            return await GetItemListAsync<DepartmentWithDivision>(InactiveDepartmentWithDivisionUri);
        }

        //Request
        public async Task<IList<RequestWithVendor>> GetRequestWithVendors()
        {
            return await GetItemListAsync<RequestWithVendor>(RequestWithVendorBaseUri);
        }
        public async Task<RequestWithVendor> GetOneRequest(int id)
        {
            return await GetItemAsync<RequestWithVendor>($"{RequestWithVendorBaseUri}{id}");
        }

        public async Task<Item> GetOneItem(int id)
        {
            return await GetItemAsync<Item>($"{GetItemUri}{id}");
        }



        //Order
        public async Task<PRWithRequest> GetNewOrder(string id)
        {
            return await GetItemAsync<PRWithRequest>($"{GetNewOrderUri}{id}");
        }

        public async Task<PRWithRequest> GetOrderAsync(int id)
        {
            return await GetItemAsync<PRWithRequest>($"{GetOrderUri}{id}");
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await GetItemListAsync<Category>(GetCategoriesUri);
        }

        public async Task<IList<PRWithRequest>> GetOrdersAsync(string id)
        {
            return await GetItemListAsync<PRWithRequest>($"{GetOrdersUri}{id}");
        }
        public async Task<IList<PRWithRequest>> GetEmployeeOrderByTypeAsync(string id, string type)
        {
            return await GetItemListAsync<PRWithRequest>($"{GetOrderByTypeUriBase}{type}/{id}");
        }
        public async Task<IList<PRWithRequest>> GetOrderByTypeAsync( string type)
        {
            return await GetItemListAsync<PRWithRequest>($"{GetOrderByTypeUriBase}{type}");
        }

        public async Task<IList<PRWithRequest>> GetPendingOrdersAsync(string id)
        {
            return await GetItemListAsync<PRWithRequest>($"{GetPendingUri}{id}");
        }

        public async Task<PRWithRequest> IncrementStatus(int id)
        {
            return await GetItemAsync<PRWithRequest>($"{IncrementStatusUri}{id}");
        }

        public async Task<PRWithRequest> MoveToCFOStatus(int id)
        {
            return await GetItemAsync<PRWithRequest>($"{CFOStatusUri}{id}");
        }

        public async Task<PRWithRequest> CancelOrderAsync(int id)
        {
            return await GetItemAsync<PRWithRequest>($"{CancelOrderUri}{id}");
        }

        public async Task<PRWithRequest> MoveToDeniedStatus(int id)
        {
            return await GetItemAsync<PRWithRequest>($"{DenyOrderUri}{id}");
        }

        public async Task<IList<PRWithRequest>> GetDeniedBySupervisorAsync(string id)
        {
            return await GetItemListAsync<PRWithRequest>($"{GetDeniedBySupervisorUri}{id}");
        }


        //Employee
        public async Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployees()
        {
           return await GetItemListAsync<EmployeeWithDepartmentAndRoomAndRole>($"{GetEmployeeBaseUri}");
        }

        public async Task<IList<Employee>> GetEmployeesAsEmployees()
        {
            return await GetItemListAsync<Employee>($"{GetEmployeeBaseUri}");
        }

        public async Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployeeByDepartment(int id)
        {
            return await GetItemListAsync<EmployeeWithDepartmentAndRoomAndRole>($"{GetEmployeeByDepartmentBaseUri}{id}");
        }

        public async Task<object> LoginEmployee(LogInViewModel logInViewModel)
        {
            var json = JsonConvert.SerializeObject(logInViewModel);
            return await SubmitPostRequestAsync(GetEmployeeLoginBaseUri, json);
        }

        public async Task<IList<Employee>> GetSupervisors()
        {
            return await GetItemListAsync<Employee>($"{GetSupervisorsBaseUri}");
        }

        public async Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetInActiveEmployees()
        {
            return await GetItemListAsync<EmployeeWithDepartmentAndRoomAndRole>($"{GetInactiveEmployeesBaseUri}");
        }

        public async Task<EmployeeWithDepartmentAndRoomAndRole> GetEmployeeAsync(string id)
        {
            return await GetItemAsync<EmployeeWithDepartmentAndRoomAndRole>($"{GetEmployeeUri}{id}");
        }

        public async Task<NotificationViewModel> GetNotification(string userId)
        {
            return await GetItemAsync<NotificationViewModel>($"{GetNotificationUri}{userId}");
        }

        //Supervisor
        public async Task<IList<PRWithRequest>> GetSubmittedAsync(string id)
        {
            return await GetItemListAsync<PRWithRequest>($"{GetSubmittedUri}{id}");
        }

        //CFO
        public async Task<IList<PRWithRequest>> GetWaitingOnCFO()
        {
            return await GetItemListAsync<PRWithRequest>($"{GetWaitingForCFOUri}");
        }

        //Roles
        public async Task<IList<IdentityRole>> GetRoles()
        {
            return await GetItemListAsync<IdentityRole>($"{GetRolesBaseUri}");
        }

        //Approval
        public async Task<IList<Approval>> GetApprovals()
        {
            return await GetItemListAsync<Approval>($"{GetApprovalBaseUri}");
        }

        //Attachments
        public async Task<RequestWithAttachmentsViewModel> GetAttachments(int requestId)
        {
            return await GetItemAsync<RequestWithAttachmentsViewModel>($"{GetAttachmentsUri}{requestId}");
        }

        public async Task AddAttachments(int requestId, IEnumerable<IFormFile> files)
        {
            var json = JsonConvert.SerializeObject(files);
            await SubmitPostRequestAsync($"{AddAttachmentsUri}{requestId}", json);
        }

        public async Task<Attachment> Download(int attachmentId)
        {
            return await GetItemAsync<Attachment>($"{DownloadAttachmentsUri}{attachmentId}");
        }

        public async Task Delete(int attachmentId, Attachment attachment)
        {
            var json = JsonConvert.SerializeObject(attachment);
            await SubmitPutRequestAsync($"{DeleteAttachmentUri}{attachmentId}", json);
        }

        // Dropdowns
        public async Task<List<SelectListItem>> GetRolesForDropdown()
        {
            var groups = await GetRoles();

            var ls = new List<SelectListItem>();

            foreach(IdentityRole role in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = role.Id,
                    Text = role.Name
                });
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetSupervisorsForDropDown()
        {
            var groups = await GetSupervisors();

            var ls = new List<SelectListItem>();

            foreach (Employee e in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = e.Id,
                    Text = e.FullName
                });
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetDepartmentsForDropDown()
        {
            var groups = await GetDepartmentsAsync();

            var ls = new List<SelectListItem>();

            foreach (DepartmentWithDivision d in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DepartmentName
                });
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetDivisionsForDropDown()
        {
            var groups = await GetDivisionsAsync();

            var ls = new List<SelectListItem>();

            foreach (DivisionWithSupervisor d in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DivisionName
                });
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetBudgetCodesForDropDown(string id)
        {
            var groups = await GetAllEmployeesBudgetCodes(id);
            var budgets = await GetBudgetsAsync();

            var ls = new List<SelectListItem>();

            foreach (EmployeeBudgetCodeViewModel d in groups)
            {
                if(d.Active == true)
                {
                    ls.Add(new SelectListItem
                    {
                        Value = d.BudgetCodeId.ToString(),
                        Text = d.BudgetCodeName
                    });
                }
               
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetRoomsForDropdown()
        {
            var groups = await GetRoomsAsync();

            var ls = new List<SelectListItem>();

            foreach (Room room in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = room.RoomName
                });
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetCategoriesForDropDown()
          {
            var groups = await GetCategoriesAsync();

             var ls = new List<SelectListItem>();

            foreach (Category cat in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = cat.Id.ToString(),
                    Text = cat.CategoryName
                });
            }
            return ls;
        }

        public async Task<List<SelectListItem>> GetEmployeesForDropDown()
        {
            var groups = await GetEmployeesAsEmployees();

            var ls = new List<SelectListItem>();

            foreach ( Employee emp in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = emp.Id,
                    Text = emp.FullName
                });
            }

            return ls;
        }


    }
}
