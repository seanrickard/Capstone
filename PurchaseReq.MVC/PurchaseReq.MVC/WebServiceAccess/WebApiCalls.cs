﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<string> CreateCampusAsync(Campus campus)
        {
            var json = JsonConvert.SerializeObject(campus);
            return await SubmitPostRequestAsync(CreateCampusWithBaseUri, json);
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

        public async Task<List<SelectListItem>> GetDivisionsForDropDown()
        {
            var groups = await GetDivisionsAsync();

            var ls = new List<SelectListItem>();

            foreach(DivisionWithSupervisor d in groups)
            {
                ls.Add(new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DivisionName
                });
            }
            return ls;
        }

        public async Task<DivisionWithSupervisor> GetDivisionAsync(int id)
        {
            return await GetItemAsync<DivisionWithSupervisor>($"{DivisionWithSupervisorBaseUri}{id}");
        }

        public async Task<string> CreateDivisionAsync(Division division)
        {
            var json = JsonConvert.SerializeObject(division);
            return await SubmitPostRequestAsync(CreateDivisionWithBaseUri, json);
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

        public async Task<string> CreateDepartmentAsync(Department department)
        {
            var json = JsonConvert.SerializeObject(department);
            return await SubmitPostRequestAsync(CreateDepartmentWithBaseUri, json);
        }

        public async Task<string> UpdateDepartment(int id, Department department)
        {
            
            string uri = $"{UpdateDepartmentBaseUri}{id}";
            var json = JsonConvert.SerializeObject(department);
            return await SubmitPutRequestAsync(uri, json);
        }

        //Request
        public async Task<IList<RequestWithVendor>> GetRequestWithVendors()
        {
            return await GetItemListAsync<RequestWithVendor>(RequestWithVendorBaseUri);
        }

        //Employee
        public async Task<IList<EmployeeWithDepartmentAndRoomAndRole>> GetEmployeeByDepartment(int id)
        {
            return await GetItemListAsync<EmployeeWithDepartmentAndRoomAndRole>($"{GetEmployeeByDepartmentBaseUri}{id}");
        }

        public async Task<object> LoginEmployee(LogInViewModel logInViewModel)
        {
            var json = JsonConvert.SerializeObject(logInViewModel);
            return await SubmitPostRequestAsync(GetEmployeeLoginBaseUri, json);
        }

    }
}
