using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDepartmentRepo : IRepo<Department>
    {
        Department GetDepartmentWithDivision(int? id);

        IEnumerable<Department> GetAllWithDivision();

        Department GetDepartmentWithEmployees(int? id);

    }
}
