using PurchaseReq.Models.Entities;
using PurchaseReq.MVC.Configuration;
using PurchaseReq.MVC.WebServiceAccess.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess
{
    public class WebApiCalls : WebApiCallsBase, IWebApiCalls
    {
        public WebApiCalls(IWebServiceLocator settings ) : base(settings)
        {

        }

        public async Task<IList<Campus>> GetCampusesAsync()
        {
            return await GetItemListAsync<Campus>(CampusBaseUri);
        }

        public async Task<Campus> GetCampusAsync(int id)
        {
            return await GetItemAsync<Campus>($"{CampusBaseUri}{id}");
        }
    }
}
