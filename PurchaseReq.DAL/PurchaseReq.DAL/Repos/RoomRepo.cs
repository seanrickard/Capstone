using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class RoomRepo : RepoBase<Room>, IRoomRepo
    {
        public Room GetRoomWithCampus(int? id)
            => Table.Include(x => x.Campus).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Room> GetAllWithCampus(int? id)
            => Table.Include(x => x.Campus).ToList();

        public Room GetRoomWithEmployees(int? id)
            => Table.Include(x => x.Employees).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Room> GetAllWithEmployees()
            => Table.Include(x => x.Employees).ToList();
    }
}
