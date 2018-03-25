using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IRoomRepo : IRepo<Room>
    {
        Room GetRoomWithCampus(int? id);

        IEnumerable<Room> GetAllWithCampus(int? id);

        Room GetRoomWithEmployees(int? id);

        IEnumerable<Room> GetAllWithEmployees();
    }
}
