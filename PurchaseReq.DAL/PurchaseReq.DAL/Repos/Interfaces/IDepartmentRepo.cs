using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDepartmentRepo : IRepo<Department>
    {
        DepartmentWithDivision GetDepartmentWithDivision(int? id);

        IEnumerable<DepartmentWithDivision> GetAllWithDivision();

        Department GetDepartmentWithEmployees(int? id);

    }
}
