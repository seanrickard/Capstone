using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDepartmentRepo : IRepo<Department>
    {
<<<<<<< HEAD
        Department GetDepartmentWithDivision(int? id);

        IEnumerable<Department> GetAllWithDivision();

        Department GetDepartmentWithEmployees(int? id);

        IEnumerable<Department> GetAllWithEmployees();
=======
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int departmentId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
