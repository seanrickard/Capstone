using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IRoomRepo : IRepo<Room>
    {
        RoomWithCampus GetRoomWithCampus(int? id);

        IEnumerable<RoomWithCampus> GetAllWithCampus();

        Room GetRoomWithEmployees(int? id);

        IEnumerable<Room> GetAllWithEmployees();

        IEnumerable<RoomWithCampus> GetRoomsForCampus(int campusId);
    }
}
