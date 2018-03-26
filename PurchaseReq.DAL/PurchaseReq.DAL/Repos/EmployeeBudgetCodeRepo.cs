using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class EmployeeBudgetCodeRepo : RepoBase<EmployeesBudgetCodes>, IEmployeeBudgetCode
    {
        public IEnumerable<EmployeesBudgetCodes> GetAllActiveEmployeeBudgetCodes(string id)
            => Table.Include(x => x.BudgetCode).Where(x => x.EmployeeId == id && x.Active == true && x.BudgetCode.Active == true).ToList();

        public IEnumerable<EmployeesBudgetCodes> GetAllEmployeesBudgetCodes(string id)
            => Table.Include(x => x.BudgetCode).Where(x => x.EmployeeId == id).ToList();

        public IEnumerable<EmployeesBudgetCodes> GetAllWithEmployeeAndBudgetCodes()
            => Table.Include(x => x.BudgetCode).Include(x => x.Employee).ToList();
    }

    
}
