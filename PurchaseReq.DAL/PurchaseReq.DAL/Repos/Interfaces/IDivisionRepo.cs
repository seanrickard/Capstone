using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IDivisionRepo : IRepo<Division>
    {
        IEnumerable<Division> GetAllDivisions();
        Division GetDivisionById(int divisionId);
    }
}
