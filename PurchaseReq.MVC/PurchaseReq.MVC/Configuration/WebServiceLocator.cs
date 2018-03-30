using Microsoft.Extensions.Configuration;

namespace PurchaseReq.MVC.Configuration
{
    public class WebServiceLocator : IWebServiceLocator
    {
        public WebServiceLocator(IConfiguration config)
        {
            var customSection = config.GetSection(nameof(WebServiceLocator));
            ServiceAddress = customSection?.GetSection(nameof(ServiceAddress))?.Value;
        }

        public string ServiceAddress { get; }
    }
}
