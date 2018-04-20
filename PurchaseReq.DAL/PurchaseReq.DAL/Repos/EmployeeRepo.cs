using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        protected readonly PurchaseReqContext Db;
        protected DbSet<Employee> Table;
        public PurchaseReqContext Context => Db;

        public RoleManager<IdentityRole> _RoleManager { get; }
        public UserManager<Employee> UserManager { get; }

        public EmployeeRepo(RoleManager<IdentityRole> roleManager, UserManager<Employee> userManager)
        {
            Db = new PurchaseReqContext();
            Table = Db.Employees;
            _RoleManager = roleManager;
            UserManager = userManager;
        }


        public IEnumerable<EmployeeWithDepartmentAndRoomAndRole> Get()
        {
            var employees = Table.Include(x => x.Room).Include(x => x.Department);
            var returnList = new List<EmployeeWithDepartmentAndRoomAndRole>();

            foreach (var employee in employees)
            {
                var roleName = UserManager.GetRolesAsync(employee).GetAwaiter().GetResult().Last();
                var actualRole = _RoleManager.Roles.Where(x => x.Name == roleName).Last();
                returnList.Add(Map(employee, employee.Department, employee.Room, actualRole));
            }
            return returnList;
        }

        public EmployeeWithDepartmentAndRoomAndRole Get(string id)
        {
            var employee = Table.Include(x => x.Room).Include(x => x.Department).Where(x => x.Id == id).Last();
            var roleName = UserManager.GetRolesAsync(employee).GetAwaiter().GetResult().Last();
            var actualRole = _RoleManager.Roles.Where(x => x.Name == roleName).Last();
            return Map(employee, employee.Department, employee.Room, actualRole);
        }


        internal EmployeeWithDepartmentAndRoomAndRole Map(Employee e, Department d, Room r, IdentityRole ir)
        {
            var employee = new EmployeeWithDepartmentAndRoomAndRole
            {
                Active = e.Active,
                Email = e.Email,
                FirstName = e.FirstName,
                Id = e.Id,
                LastName = e.LastName
            };

            if(d != null)
            {
                employee.DepartmentId = d?.Id;
                employee.DepartmentName = d?.DepartmentName;
            }

            if(r != null)
            {
                employee.RoomId = r.Id;
                employee.RoomName = r.RoomName;
            }

            if(ir != null)
            {
                employee.RoleId = ir?.Id;
                employee.RoleName = ir?.Name;
            }

            return employee;
        }

        public IEnumerable<EmployeeWithDepartmentAndRoomAndRole> GetByDepartment(int departmentId)
        {
            return Get().Where(x => x.DepartmentId == departmentId);
                
        }

        public IEnumerable<EmployeeWithDepartmentAndRoomAndRole> GetByDivision(int divisionId)
        {
            var employees = Table.Include(x => x.Room).Include(x => x.Department).ThenInclude(x => x.Division).Where(x => x.Department.Division.Id == divisionId);
            var returnList = new List<EmployeeWithDepartmentAndRoomAndRole>();

            foreach (var employee in employees)
            {
                var roleName = UserManager.GetRolesAsync(employee).GetAwaiter().GetResult().Last();
                var actualRole = _RoleManager.Roles.Where(x => x.Name == roleName).Last();
                returnList.Add(Map(employee, employee.Department, employee.Room, actualRole));
            }
            return returnList;
        }

        //Will return null if there is no Notification for that user role
        public NotificationViewModel GetNotification(string userId)
        {
            var statuses = Context.Statuses;
            var user = Table.FirstOrDefault(x => x.Id == userId);

            if(UserManager.IsInRoleAsync(user, "Supervisor").Result)
            {
                return new NotificationViewModel
                {
                    FullName = user.FullName,
                    WaitingForSupervisor = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Waiting for Supervisor Approval").First().Id),
                    WaitingForCFO = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Waiting for CFO approval").First().Id),
                    WaitingToBeOrdered = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Approved").First().Id),
                    BeingDeliverd = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Ordered").First().Id),
                    NumberNeedingToBeApproved = Context.Orders.Count(x => x.Employee.Department.Division.SupervisorId == userId && x.StatusId == statuses.Where(s => s.StatusName == "Waiting for Supervisor Approval").First().Id)
                };
            }
            else if (UserManager.IsInRoleAsync(user, "User").Result)
            {

                return new NotificationViewModel
                {
                    FullName = user.FullName,
                    WaitingForSupervisor = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Waiting for Supervisor Approval").First().Id),
                    WaitingForCFO = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Waiting for CFO approval").First().Id),
                    WaitingToBeOrdered = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Approved").First().Id),
                    BeingDeliverd = Context.Orders.Count(x => x.EmployeeId == user.Id && x.StatusId == statuses.Where(s => s.StatusName == "Ordered").First().Id),
                };
            }
            else if (UserManager.IsInRoleAsync(user, "CFO").Result)
            {
                return new NotificationViewModel
                {
                    FullName = user.FullName,
                    NumberNeedingToBeApproved = Context.Orders.Count(x => x.StatusId == statuses.Where(s => s.StatusName == "Waiting for CFO approval").First().Id),
                    NumberNeedingToBePurchased = Context.Orders.Count(x => x.StatusId == statuses.Where(s => s.StatusName == "Approved").First().Id)
                };
            }
            else if (UserManager.IsInRoleAsync(user, "Purchasing").Result)
            {
                return new NotificationViewModel
                {
                    FullName = user.FullName,
                    NumberNeedingToBePurchased = Context.Orders.Count(x => x.StatusId == statuses.Where(s => s.StatusName == "Approved").First().Id)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
