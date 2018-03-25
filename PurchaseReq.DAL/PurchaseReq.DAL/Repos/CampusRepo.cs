using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class CampusRepo : RepoBase<Campus>, ICampusRepo
    {
        public Campus GetCampusWithRooms(int? id)
            => Table.Include(x => x.Rooms).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Campus> GetAllWithRooms()
            => Table.Include(x => x.Rooms);

        public Campus GetCampusWithAddress(int? id)
            => Table.Include(x => x.Address).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Campus> GetAllWithAddress()
            => Table.Include(x => x.Address);
    }
}
