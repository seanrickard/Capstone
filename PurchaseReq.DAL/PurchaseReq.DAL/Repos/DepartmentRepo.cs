using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class DepartmentRepo : RepoBase<Department>, IDepartmentRepo
    {
        public Department GetDepartmentWithDivision(int? id)
            => Table.Include(x => x.Division).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Department> GetAllWithDivision()
            => Table.Include(x => x.Division);

        public Department GetDepartmentWithEmployees(int? id)
            => Table.Include(x => x.Employees).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Department> GetAllWithEmployees()
            => Table.Include(x => x.Employees);
    }
}
