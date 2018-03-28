using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ICampusRepo : IRepo<Campus>
    {

        Campus GetCampusWithRooms(int? id);

        IEnumerable<Campus> GetAllWithRooms();

        CampusWithAddress GetCampusWithAddress(int? id);

        IEnumerable<CampusWithAddress> GetAllWithAddress();
    }
}
