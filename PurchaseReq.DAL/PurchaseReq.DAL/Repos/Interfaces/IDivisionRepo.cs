using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDivisionRepo : IRepo<Division>
    {
        Division GetDivisionWithDepartments(int? id);

        DivisionWithSupervisor GetDivisionWithSupervisor(int? id);

        IEnumerable<Division> GetAllWithDepartments();

        IEnumerable<DivisionWithSupervisor> GetAllWithSupervisor();

    }
}
