using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class DepartmentRepo : RepoBase<Department>, IDepartmentRepo
    {


        public DepartmentWithDivision GetDepartmentWithDivision(int? id)
            => Table.Include(x => x.Division)
                .Select(item => GetRecord(item, item.Division)).SingleOrDefault(x => x.Id == id);

        public IEnumerable<DepartmentWithDivision> GetAllWithDivision()
            => Table.Include(x => x.Division)
                .Select(item => GetRecord(item, item.Division));

        public Department GetDepartmentWithEmployees(int? id)
            => Table.Include(x => x.Employees).SingleOrDefault(x => x.Id == id);


        internal DepartmentWithDivision GetRecord(Department de, Division di)
            => new DepartmentWithDivision()
            {
                Id = de.Id,
                TimeStamp = de.TimeStamp,
                Division = di,
                Active = de.Active,
                DepartmentName = de.DepartmentName,
                DivisionId = di.Id,
                Divisions = Context.Divisions.ToList() 
            };
    }
}
