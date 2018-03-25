using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDivisionRepo : IRepo<Division>
    {
        Division GetDivisionWithDepartments(int? id);

        Division GetDivisionWithSupervisor(int? id);

        IEnumerable<Division> GetAllWithDepartments();

        IEnumerable<Division> GetAllWithSupervisor();

    }
}
