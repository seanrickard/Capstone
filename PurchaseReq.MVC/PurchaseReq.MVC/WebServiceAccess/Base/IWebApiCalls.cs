using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<CampusWithAddress>> GetCampusesAsync();
        Task<CampusWithAddress> GetCampusAsync(int id);
        Task<IList<BudgetCodeWithAmount>> GetBudgetsAsync();
        Task<BudgetCodeWithAmount> GetBudgetAsync(int id);
        Task<IList<DivisionWithSupervisor>> GetDivisionsAsync();
        Task<DivisionWithSupervisor> GetDivisionAsync(int id);
        Task<IList<DepartmentWithDivision>> GetDepartmentsAsync();
        Task<DepartmentWithDivision> GetDepartmentAsync(int id);
    }
}
