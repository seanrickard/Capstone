using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<Campus>> GetCampusesAsync();
        Task<Campus> GetCampusAsync(int id);
    }
}
