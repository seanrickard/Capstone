using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IEmployeeRepo
    {
        IEnumerable<EmployeeWithDepartmentAndRoomAndRole> Get();

        EmployeeWithDepartmentAndRoomAndRole Get(string id);


    }
}
