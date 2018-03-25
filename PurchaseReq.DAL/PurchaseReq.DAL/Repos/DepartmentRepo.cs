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
    public class DepartmentRepo : RepoBase<Department>, IDepartmentRepo
    {
        public DepartmentRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public DepartmentRepo()
        {

        }

        public Department GetOneWithEmployees(int? id) => Table.Include(x => x.Employees).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Department> GetAllWithEmployees() => Table.Include(x => x.Employees).ToList();
        public Department GetOneWithDivision(int? id) => Table.Include(x => x.Division).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Department> GetAllWithDivisions() => Table.Include(x => x.Division).ToList();
        public IEnumerable<Department> GetAllDepartments() => Table.OrderBy(x => x.DepartmentName);
        public override IEnumerable<Department> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.DepartmentName), skip, take);
        public Department GetDepartmentById(int departmentId) => Table.FirstOrDefault(x => x.Id == departmentId);
    }
}
