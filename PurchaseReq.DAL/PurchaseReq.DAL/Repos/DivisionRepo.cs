using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class DivisionRepo : RepoBase<Division>, IDivisionRepo
    {
        public Division GetDivisionWithDepartments(int? id)
            => Table.Include(x => x.Departments).SingleOrDefault(x=> x.Id == id);

        public Division GetDivisionWithSupervisor(int? id)
            => Table.Include(x => x.Supervisor).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Division> GetAllWithDepartments()
            => Table.Include(x => x.Departments).ToList();

        public IEnumerable<Division> GetAllWithSupervisor()
            => Table.Include(x => x.Supervisor).ToList();
    }
}
