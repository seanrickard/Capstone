using Newtonsoft.Json;
using PurchaseReq.MVC.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess.Base
{
    public abstract class WebApiCallsBase
    {
        protected readonly string ServiceAddress;

        //Campus 
        protected readonly string CampusWithAddressBaseUri;
        protected readonly string CreateCampusWithBaseUri;
        protected readonly string RoomsByCampusBaseUri;
        protected readonly string GetRoomsBaseUri;
        protected readonly string GetInactiveCampusesUri;

        //Budget Codes
        protected readonly string BudgetCodeWithAmountBaseUri;
        protected readonly string BudgetCodeWithEmployeesUri;
        protected readonly string BudgetCodesForEmployeesUri;


        //Division
        protected readonly string DivisionBaseUri;
        protected readonly string DivisionWithSupervisorBaseUri;
        protected readonly string InActiveDivisionWithSupervisorBaseUri;

        //Department
        protected readonly string DepartmentWithDivisionBaseUri;
        protected readonly string DepartmentByDivisionBaseUri;
        protected readonly string CreateDepartmentWithBaseUri;
        protected readonly string UpdateDepartmentBaseUri;
        protected readonly string InactiveDepartmentWithDivisionUri;

        //Request
        protected readonly string RequestWithVendorBaseUri;

        //Order
        protected readonly string GetNewOrderUri;
        protected readonly string GetCategoriesUri;
        protected readonly string GetOrderUri;
        protected readonly string GetOrdersUri;
        protected readonly string GetOrderByTypeUriBase;
        protected readonly string IncrementStatusUri;
        protected readonly string CFOStatusUri;
        protected readonly string GetPendingUri;
        protected readonly string CancelOrderUri;



        //Employee
        protected readonly string GetEmployeeByDepartmentBaseUri;
        protected readonly string GetEmployeeLoginBaseUri;        
        protected readonly string GetEmployeeBaseUri;
        protected readonly string GetInactiveEmployeesBaseUri;
        protected readonly string GetEmployeeUri;
        protected readonly string GetNotificationUri;

        //Supervisor
        protected readonly string GetSubmittedUri;
        protected readonly string GetWaitingForCFOUri;

        //Roles
        protected readonly string GetRolesBaseUri;
        protected readonly string GetSupervisorsBaseUri;

        protected readonly string BaseUri;

        //Approval
        protected readonly string GetApprovalBaseUri;

        //Attachment 
        protected readonly string GetAttachmentsBaseUri;
        protected readonly string GetAttachmentsUri;
        protected readonly string AddAttachmentsUri;
        protected readonly string DownloadAttachmentsUri;

        //EmployeeBudgetCodes
        protected readonly string CreateEmployeeBudgetCodeUri;
        protected readonly string UpdateEmployeeBudgetCodeUri;
        protected readonly string ActiveBudgetCodesForEmployeesUri;
        protected readonly string DeleteAttachmentUri;

        protected WebApiCallsBase(IWebServiceLocator settings)
        {
            ServiceAddress = settings.ServiceAddress;

            
            BaseUri = $"{ServiceAddress}api/";

            //Campus
            CampusWithAddressBaseUri = $"{ServiceAddress}api/Campus/GetWithAddress/";
            RoomsByCampusBaseUri = $"{ServiceAddress}api/Room/GetByCampus/";
            GetRoomsBaseUri = $"{ServiceAddress}api/Room/Get/";
            GetInactiveCampusesUri = $"{ServiceAddress}api/Campus/GetInActive/";

            //Division
            DivisionWithSupervisorBaseUri = $"{ServiceAddress}api/Division/GetWithSupervisor/";
            InActiveDivisionWithSupervisorBaseUri = $"{BaseUri}Division/GetInActive/";

            //Department
            DepartmentByDivisionBaseUri = $"{ServiceAddress}api/Department/GetByDivision/";
            DepartmentWithDivisionBaseUri = $"{ServiceAddress}api/Department/Get/";
            InactiveDepartmentWithDivisionUri = $"{ServiceAddress}api/Department/GetInActive";

            //Employees
            GetEmployeeByDepartmentBaseUri = $"{ServiceAddress}api/Employee/GetByDepartment/";
            GetEmployeeBaseUri= $"{ServiceAddress}api/Employee/Get/";
            GetEmployeeLoginBaseUri = $"{ServiceAddress}api/Employee/Login/";
            GetInactiveEmployeesBaseUri = $"{BaseUri}Employee/GetInactive/";
            GetEmployeeUri = $"{BaseUri}Employee/Get/";
            GetNotificationUri = $"{BaseUri}Employee/GetNotification/";

            //Budget

            BudgetCodeWithAmountBaseUri = $"{ServiceAddress}api/BudgetCode/Get/";
            BudgetCodeWithEmployeesUri = $"{ServiceAddress}api/EmployeeBudgetCode/GetEmployeesInBudgetCode/";
            BudgetCodesForEmployeesUri = $"{ServiceAddress}api/EmployeeBudgetCode/GetAllForEmployee/";
            CreateEmployeeBudgetCodeUri = $"{ServiceAddress}api/EmployeeBudgetCode/Create/";
            UpdateEmployeeBudgetCodeUri = $"{ServiceAddress}api/EmployeeBudgetCode/Update/";
            ActiveBudgetCodesForEmployeesUri = $"{ServiceAddress}api/EmployeeBudgetCode/GetActiveEmployeesInBudgetCode/";

            //Request

            RequestWithVendorBaseUri = $"{ServiceAddress}api/Request/Get/";

            //Order
            GetNewOrderUri = $"{ServiceAddress}api/Order/GetNewOrder/";
            GetCategoriesUri = $"{ServiceAddress}api/Category/Get/";
            GetOrderByTypeUriBase = $"{ServiceAddress}api/Order/Get";
            GetOrderUri = $"{ServiceAddress}api/Order/Get/";
            GetOrdersUri = $"{ServiceAddress}api/Order/GetAll/";
            IncrementStatusUri = $"{ServiceAddress}api/Order/MoveOrderLifeCycleUp/";
            CFOStatusUri = $"{ServiceAddress}api/Order/MoveToCFOStatus/";
            GetPendingUri = $"{ServiceAddress}api/Order/GetPending/";
            CancelOrderUri = $"{ServiceAddress}api/Order/CancellOrder/";

            //Supervisor
            GetSubmittedUri = $"{ServiceAddress}api/Order/GetWaitingSupervisor/";
            GetWaitingForCFOUri = $"{ServiceAddress}api/Order/GetWaitingCFO/";

            //Roles
            GetSupervisorsBaseUri = $"{ServiceAddress}api/Role/GetSupervisors";
            GetRolesBaseUri = $"{ServiceAddress}api/Role/Get";

            //Approval
            GetApprovalBaseUri = $"{ServiceAddress}api/Approval/Get/";

            //Attachment

            GetAttachmentsBaseUri = $"{ServiceAddress}api/Attachment/";
            GetAttachmentsUri = $"{GetAttachmentsBaseUri}GetAll/";
            AddAttachmentsUri = $"{GetAttachmentsBaseUri}Create/";
            DownloadAttachmentsUri = $"{GetAttachmentsBaseUri}Get/";
            DeleteAttachmentUri = $"{GetAttachmentsBaseUri}Delete/";
    }



        internal async Task<string> GetJsonFromGetResponseAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    if(!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"The Call to {uri} failed. Status code: {response.StatusCode}");
                    }
                    Console.WriteLine("response Successful");
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception e)
            {
                //Do something intelligent here if you can
                Console.WriteLine(e);
                throw;
            }
        }

        internal async Task<T> GetItemAsync<T>(string uri) where T : class, new()
        {
            try
            {
                var json = await GetJsonFromGetResponseAsync(uri);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(Exception e )
            {
                // intelligent
                Console.WriteLine(e);
                throw;
            }
        }

        internal async Task<IList<T>> GetItemListAsync<T>(string uri) where T : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<IList<T>>(await GetJsonFromGetResponseAsync(uri));
            }
            catch(Exception e)
            {
                //intelligent
                Console.WriteLine(e);
                throw;
            }
        }

        protected static async Task<string> ExecuteRequestAndProcessResponse(string uri, Task<HttpResponseMessage> task)
        {
            try
            {
                var response = await task;   
                
                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception($"The Call to {uri} failed. Status code: {response.StatusCode}");
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                //something
                Console.WriteLine(e);
                throw;
            }
        }

        protected StringContent CreateStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected async Task<string> SubmitPostRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                var task = client.PostAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);               
            }
        }

        protected async Task<string> SubmitPutRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> task = client.PutAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }

        protected async Task SubmitDeleteRequestAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(uri);
                    var response = await deleteAsync;

                    if(!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}