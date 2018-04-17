﻿using Microsoft.AspNetCore.Identity;
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
            string type = input.ToString().Remove(0, 28);
            return await SubmitPostRequestAsync(BaseUri + type + "/Create/", json);
        }

        public async Task<string> UpdateAsync<T>(int id, T input)
        {
            var json = JsonConvert.SerializeObject(input);
            string type = input.ToString().Remove(0, 28);
            return await SubmitPutRequestAsync(BaseUri + type + "/Update/" + id + "/", json);
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

        //Request
        public async Task<IList<RequestWithVendor>> GetRequestWithVendors()
        {
            return await GetItemListAsync<RequestWithVendor>(RequestWithVendorBaseUri);
        }

        //Order
        public async Task<PRWithRequest> GetNewOrder(string id)
        {
            return await GetItemAsync<PRWithRequest>($"{GetNewOrderUri}{id}");
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await GetItemListAsync<Category>(GetCategoriesUri);
        }


        //Employee
        public async Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployees()
        {
           return await GetItemListAsync<EmployeeWithDepartmentAndRoomAndRole>($"{GetEmployeeBaseUri}");
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

        //Roles
        public async Task<IList<IdentityRole>> GetRoles()
        {
            return await GetItemListAsync<IdentityRole>($"{GetRolesBaseUri}");
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

        public async Task<List<SelectListItem>> GetBudgetCodesForDropDown()
        {
            var groups = await GetBudgetsAsync();

            var ls = new List<SelectListItem>();

            foreach (BudgetCodeWithAmount d in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.BudgetCodeName
                });
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


    }
}
