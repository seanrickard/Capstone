using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class CampusRepo : RepoBase<Campus>, ICampusRepo
    {
        public Campus GetCampusWithRooms(int? id)
            => Table.Include(x => x.Rooms).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Campus> GetAllWithRooms()
            => Table.Include(x => x.Rooms).ToList();

        public CampusWithAddress GetCampusWithAddress(int? id)
            => Table.Include(x => x.Address)
                .Select(item => GetRecord(item, item.Address)).SingleOrDefault(x => x.Id == id);

        public IEnumerable<CampusWithAddress> GetAllWithAddress()
            => Table.Include(x => x.Address).Select(item => GetRecord(item, item.Address));




        internal CampusWithAddress GetRecord(Campus c, Address a)
            => new CampusWithAddress()
            {
                Id = c.Id,
                Active = c.Active,
                TimeStamp = c.TimeStamp,
                CampusName = c.CampusName,
                AddressId = a.Id,
                City = a.City,
                State = a.State,
                StreetAddress = a.StreetAddress,
                Zip = a.Zip
            };
    }
}
