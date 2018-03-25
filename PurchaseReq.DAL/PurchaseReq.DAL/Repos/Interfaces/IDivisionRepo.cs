using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDivisionRepo : IRepo<Division>
    {
<<<<<<< HEAD
        Division GetDivisionWithDepartments(int? id);

        Division GetDivisionWithSupervisor(int? id);

        IEnumerable<Division> GetAllWithDepartments();

        IEnumerable<Division> GetAllWithSupervisor();


=======
        IEnumerable<Division> GetAllDivisions();
        Division GetDivisionById(int divisionId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
