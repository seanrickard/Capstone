using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IEmployeeBudgetCode : IRepo<EmployeesBudgetCodes>
    {
        IEnumerable<EmployeesBudgetCodes> GetAllActiveEmployeeBudgetCodes(string id);

        IEnumerable<EmployeesBudgetCodes> GetAllEmployeesBudgetCodes(string id);

        IEnumerable<EmployeesBudgetCodes> GetAllWithEmployeeAndBudgetCodes();
    }
}
