using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos
{
    public class EmployeesBudgetCodeRepos : RepoBase<EmployeesBudgetCodes>, IEmployeesBudgetCodesRepo
    {
        public EmployeesBudgetCodeRepos(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<EmployeesBudgetCodes> GetAllEmployeesBudgetCodes() => Table.OrderBy(x => x.Id);

        public EmployeesBudgetCodes GetEmployeesBudgetCodeById(int employeesBudgetCodesId) => Table.FirstOrDefault(x => x.Id == employeesBudgetCodesId); 
        
    }
}
