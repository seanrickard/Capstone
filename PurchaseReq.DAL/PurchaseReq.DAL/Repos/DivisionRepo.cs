using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos
{
    public class DivisionRepo : RepoBase<Division>, IDivisionRepo
    {
        public DivisionRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public DivisionRepo()
        {

        }

        public Division GetOneWithDepartments(int? id) => Table.Include(x => x.Departments).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Division> GetAllWithDepartments() => Table.Include(x => x.Departments).ToList();
        public Division GetOneWithSupervisor(int? id) => Table.Include(x => x.Supervisor).SingleOrDefault(x => x.Id == id);
        public IEnumerable<Division> GetAllWithSupervisors() => Table.Include(x => x.Supervisor).ToList();
        public Division GetRootDivision() => Table.Include(x => x.Supervisor).Single(x => x.SupervisorId == null);
        public IEnumerable<Division> GetAllDivisions() => Table.OrderBy(x => x.DivisionName);
        public override IEnumerable<Division> GetRange(int skip, int take) => GetRange(Table.OrderBy(x => x.DivisionName), skip, take);
        public Division GetDivisionById(int divisionId) => Table.FirstOrDefault(x => x.Id == divisionId);
    }
}
