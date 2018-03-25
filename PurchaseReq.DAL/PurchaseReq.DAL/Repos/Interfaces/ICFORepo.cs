using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ICFORepo : IRepo<CFO>
    {
        IEnumerable<CFO> GetAllCFOs();
        CFO GetCFOById(int CFOId);
    }
}
