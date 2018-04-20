using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IEmployeeRepo
    {
        IEnumerable<EmployeeWithDepartmentAndRoomAndRole> Get();

        EmployeeWithDepartmentAndRoomAndRole Get(string id);

        IEnumerable<EmployeeWithDepartmentAndRoomAndRole> GetByDepartment(int departmentId);

        IEnumerable<EmployeeWithDepartmentAndRoomAndRole> GetByDivision(int divisionId);

        NotificationViewModel GetNotification(string userId);
    }
}
