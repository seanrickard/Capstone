using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IEmployeeBudgetCodeRepo : IRepo<EmployeesBudgetCodes>
    {
        IEnumerable<EmployeeBudgetCodeViewModel> GetAllActiveEmployeeBudgetCodes(string id);

        IEnumerable<EmployeeBudgetCodeViewModel> GetAllEmployeesBudgetCodes(string id);

        IEnumerable<EmployeeBudgetCodeViewModel> GetAllWithEmployeeAndBudgetCodes();

        IEnumerable<EmployeeBudgetCodeViewModel> GetAllEmployeesInBudgetCode(int id);
    }
}
