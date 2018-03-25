using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IEmployeesBudgetCodesRepo : IRepo<EmployeesBudgetCodes>
    {
        IEnumerable<EmployeesBudgetCodes> GetAllEmployeesBudgetCodes();
        EmployeesBudgetCodes GetEmployeesBudgetCodeById(int employeesBudgetCodesId);
    }
}
