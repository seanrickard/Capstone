using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class RoomRepo : RepoBase<Room>, IRoomRepo
    {
        private readonly CampusRepo _campusRepo = new CampusRepo();

        public RoomWithCampus GetRoomWithCampus(int? id)
            => Table.Include(x => x.Campus)
                .Select(item => GetRecord(item, item.Campus)).SingleOrDefault(x => x.Id == id);

        public IEnumerable<RoomWithCampus> GetAllWithCampus()
            => Table.Include(x => x.Campus).Select(item => GetRecord(item, item.Campus));

        public Room GetRoomWithEmployees(int? id)
            => Table.Include(x => x.Employees).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Room> GetAllWithEmployees()
            => Table.Include(x => x.Employees).ToList();

        public IEnumerable<RoomWithCampus> GetRoomsForCampus(int campusId)
            => Table.Include(x => x.Campus).Where(x => x.CampusId == campusId)
                .Select(item => GetRecord(item, item.Campus));


        internal RoomWithCampus GetRecord(Room ym, Campus ca)
            => new RoomWithCampus()
            {
               Id = ym.Id,
               Campus = _campusRepo.GetCampusWithAddress(ca.Id),
               Active = ym.Active,
               RoomName = ym.RoomName,
               CampusId = ca.Id,
               RoomCode = ym.RoomCode,
               TimeStamp = ym.TimeStamp
            };
    }
}
