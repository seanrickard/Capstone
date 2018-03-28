using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{

    public class DivisionRepo : RepoBase<Division>, IDivisionRepo
    {
        private readonly UserManager<Employee> _userManger;

        public DivisionRepo(UserManager<Employee> manager)
        {
            _userManger = manager;
        }

        public Division GetDivisionWithDepartments(int? id)
            => Table.Include(x => x.Departments).SingleOrDefault(x=> x.Id == id);

        public DivisionWithSupervisor GetDivisionWithSupervisor(int? id)
            => Table.Include(x => x.Supervisor)
                .Select(item => GetRecord(item, item.Supervisor))
                .SingleOrDefault(x => x.Id == id);

        public IEnumerable<Division> GetAllWithDepartments()
            => Table.Include(x => x.Departments).ToList();

        public IEnumerable<DivisionWithSupervisor> GetAllWithSupervisor()
            => Table.Include(x => x.Supervisor)
                .Select(item => GetRecord(item, item.Supervisor));

        //Pretty Dirty getting Managers like this
        internal DivisionWithSupervisor GetRecord(Division d, Employee e)
            => new DivisionWithSupervisor()
            {
                Id = d.Id,
                Active = d.Active,
                TimeStamp = d.TimeStamp,
                Supervisor = e,
                SupervisorId = e.Id,
                DivisionName = d.DivisionName,
                SupervisorList = _userManger.GetUsersInRoleAsync("Supervisor").Result.ToList()
            };
    }
}
