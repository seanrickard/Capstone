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

        public async Task<IList<CampusWithAddress>> GetCampusesAsync()
        {
            return await GetItemListAsync<CampusWithAddress>(CampusWithAddressBaseUri);
        }

        public async Task<CampusWithAddress> GetCampusAsync(int id)
        {
            return await GetItemAsync<CampusWithAddress>($"{CampusWithAddressBaseUri}{id}");
        }

        public async Task<IList<BudgetCodeWithAmount>> GetBudgetsAsync()
        {
            return await GetItemListAsync<BudgetCodeWithAmount>(BudgetCodeWithAmountBaseUri);
        }

        public async Task<BudgetCodeWithAmount> GetBudgetAsync(int id)
        {
            return await GetItemAsync<BudgetCodeWithAmount>($"{BudgetCodeWithAmountBaseUri}{id}");
        }

        public async Task<IList<DivisionWithSupervisor>> GetDivisionsAsync()
        {
            return await GetItemListAsync<DivisionWithSupervisor>(DivisionWithSupervisorBaseUri);
        }

        public async Task<DivisionWithSupervisor> GetDivisionAsync(int id)
        {
            return await GetItemAsync<DivisionWithSupervisor>($"{DivisionWithSupervisorBaseUri}{id}");
        }

        public async Task<IList<DepartmentWithDivision>> GetDepartmentsAsync()
        {
            return await GetItemListAsync<DepartmentWithDivision>(DepartmentWithDivisionBaseUri);
        }

        public async Task<DepartmentWithDivision> GetDepartmentAsync(int id)
        {
            return await GetItemAsync<DepartmentWithDivision>($"{DepartmentWithDivisionBaseUri}{id}");
        }
    }
}
