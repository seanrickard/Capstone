using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ICampusRepo : IRepo<Campus>
    {

        Campus GetCampusWithRooms(int? id);

        IEnumerable<Campus> GetAllWithRooms();

        Campus GetCampusWithAddress(int? id);

        IEnumerable<Campus> GetAllWithAddress();
    }
}
