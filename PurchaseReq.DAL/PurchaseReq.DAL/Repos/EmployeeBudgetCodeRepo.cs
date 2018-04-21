using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    //Need to come back to this
    public class EmployeeBudgetCodeRepo : RepoBase<EmployeesBudgetCodes>, IEmployeeBudgetCodeRepo
    {
        public IEnumerable<EmployeeBudgetCodeViewModel> GetAllActiveEmployeeBudgetCodes(string id)
            => Table.Include(x => x.BudgetCode).Where(x => x.EmployeeId == id && x.Active == true && x.BudgetCode.Active == true)
                .Select(item => GetRecord(item, item.Employee, item.BudgetCode));

        public IEnumerable<EmployeeBudgetCodeViewModel> GetAllEmployeesBudgetCodes(string id)
            => Table.Include(x => x.BudgetCode).Where(x => x.EmployeeId == id)
                .Select(item => GetRecord(item, item.Employee, item.BudgetCode));

        public IEnumerable<EmployeeBudgetCodeViewModel> GetAllEmployeesInBudgetCode(int id)
            => Table.Include(x => x.BudgetCode).Where(x => x.BudgetCodeId == id)
                .Select(item => GetRecord(item, item.Employee, item.BudgetCode));

        public IEnumerable<EmployeeBudgetCodeViewModel> GetAllWithEmployeeAndBudgetCodes()
            => Table.Include(x => x.BudgetCode).Include(x => x.Employee)
                .Select(item => GetRecord(item, item.Employee, item.BudgetCode));

        public IEnumerable<EmployeeBudgetCodeViewModel> GetAllActiveEmployeesInBudgetCode(int id)
        {
            return Table.Include(x => x.BudgetCode).Where(x => x.BudgetCodeId == id && x.Active == true)
                           .Select(item => GetRecord(item, item.Employee, item.BudgetCode));
        }




        internal EmployeeBudgetCodeViewModel GetRecord(EmployeesBudgetCodes eb, Employee e, BudgetCode b)
            => new EmployeeBudgetCodeViewModel()
            {
                Id = eb.Id,
                Active = eb.Active,
                BudgetCodeId = b.Id,
                EmployeeId = e.Id,
                TimeStamp = eb.TimeStamp,
                BudgetCodeName = b.BudgetCodeName,
                EmployeeName = e.FullName
            };
    }
}
