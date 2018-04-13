using Microsoft.AspNetCore.Identity;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IRoleRepo
    {
        IEnumerable<IdentityRole> GetRoles();

        Task<IEnumerable<Employee>> GetSupervisor();

        Task<IEnumerable<Employee>> GetUsers();

        Task<IEnumerable<Employee>> GetPurchasing();

        Task<IEnumerable<Employee>> GetAuditors();

        Task<IEnumerable<Employee>> GetCFO();

        Task<IEnumerable<Employee>> GetAdmins();

        Task<bool> AddToSupervisor(string employeeId);

        Task<bool> AddToCFO(string employeeId);

        Task<bool> AddToPurchasing(string employeeId);

        Task<bool> AddToAuditor(string employeeId);

        Task<bool> AddToUsers(string employeeId);

        Task<bool> AddToAdmin(string employeeId);
    }
}
