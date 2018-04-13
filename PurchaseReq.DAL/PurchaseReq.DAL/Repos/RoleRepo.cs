using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseReq.DAL.Repos
{
    public class RoleRepo : IRoleRepo
    {

        protected readonly PurchaseReqContext Db;
        protected DbSet<IdentityRole> Table;
        public PurchaseReqContext Context => Db;

        public UserManager<Employee> _UserManager { get; }
        public RoleManager<IdentityRole> _RoleManager { get; }

        public RoleRepo(UserManager<Employee> _userManager, RoleManager<IdentityRole> roleManager)
        {
            Db = new PurchaseReqContext();
            Table = Db.Roles;
            _UserManager = _userManager;
            _RoleManager = roleManager;
        }

        //Getters
        public async Task<IEnumerable<Employee>> GetAuditors()
        {
            return await _UserManager.GetUsersInRoleAsync("Auditor");
        }

        public async Task<IEnumerable<Employee>> GetCFO()
        {
            return await _UserManager.GetUsersInRoleAsync("CFO");
        }

        public async Task<IEnumerable<Employee>> GetPurchasing()
        {
            return await _UserManager.GetUsersInRoleAsync("Purchasing");
        }

        public IEnumerable<IdentityRole> GetRoles() => Table;


        public async Task<IEnumerable<Employee>> GetSupervisor()
        {
            return await _UserManager.GetUsersInRoleAsync("Supervisor");
        }

        public async Task<IEnumerable<Employee>> GetUsers()
        {
            return await _UserManager.GetUsersInRoleAsync("User");
        }

        public async Task<IEnumerable<Employee>> GetAdmins()
        {
          return await _UserManager.GetUsersInRoleAsync("Admin");
        }

        //Start Add Methods
        public async Task<bool> AddToSupervisor(string employeeId)
        {
            return await AddToRole(employeeId, "Supervisor");
        }

        public async Task<bool> AddToCFO(string employeeId)
        {
            return await AddToRole(employeeId, "CFO");
        }

        public async Task<bool> AddToPurchasing(string employeeId)
        {
            return await AddToRole(employeeId, "Purchasing");
        }

        public async Task<bool> AddToAuditor(string employeeId)
        {
            return await AddToRole(employeeId, "Auditor");
        }

        public async Task<bool> AddToUsers(string employeeId)
        {
            return await AddToRole(employeeId, "User");
        }

        public async Task<bool> AddToAdmin(string employeeId)
        {
            return await AddToRole(employeeId, "Admin");
        }

        public async Task<bool> AddToRoleById(string employeeId, string roleId)
        {
            var role = await _RoleManager.FindByIdAsync(roleId);
            return await AddToRole(employeeId, role.Id);
        }

        internal async Task<bool> AddToRole(string Id, string roleName)
        {
            var user = await _UserManager.FindByIdAsync(Id);
            var allRoles = _RoleManager.Roles.Select(x => x.Name).ToList();
            await _UserManager.RemoveFromRolesAsync(user, allRoles);

            var result = await _UserManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }
    }
}
