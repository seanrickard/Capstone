using Newtonsoft.Json;
using PurchaseReq.MVC.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseReq.MVC.WebServiceAccess.Base
{
    public abstract class WebApiCallsBase
    {
        protected readonly string ServiceAddress;
        protected readonly string CampusBaseUri;

        protected WebApiCallsBase(IWebServiceLocator settings)
        {
            ServiceAddress = settings.ServiceAddress;
            CampusBaseUri = $"{ServiceAddress}api/Campus/Get/";
        }

        internal async Task<string> GetJsonFromGetResponseAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine("In GetJsonFromGetResponseAsync. uri : " + uri);
                    var response = await client.GetAsync(uri);
                    if(!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"The Call to {uri} failed. Status code: {response.StatusCode}");
                    }
                    Console.WriteLine("response Successful");
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception e)
            {
                //Do something intelligent here if you can
                Console.WriteLine(e);
                throw;
            }
        }

        internal async Task<T> GetItemAsync<T>(string uri) where T : class, new()
        {
            try
            {
                var json = await GetJsonFromGetResponseAsync(uri);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch(Exception e )
            {
                // intelligent
                Console.WriteLine(e);
                throw;
            }
        }

        internal async Task<IList<T>> GetItemListAsync<T>(string uri) where T : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<IList<T>>(await GetJsonFromGetResponseAsync(uri));
            }
            catch(Exception e)
            {
                //intelligent
                Console.WriteLine(e);
                throw;
            }
        }

        protected static async Task<string> ExecuteRequestAndProcessResponse(string uri, Task<HttpResponseMessage> task)
        {
            try
            {
                var response = await task;
                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception($"The Call to {uri} failed. Status code: {response.StatusCode}");
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                //something
                Console.WriteLine(e);
                throw;
            }
        }

        protected StringContent CreateStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected async Task<string> SubmitPostRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                var task = client.PostAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }

        protected async Task<string> SubmitPutRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> task = client.PutAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }

        protected async Task SubmitDeleteRequestAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(uri);
                    var response = await deleteAsync;

                    if(!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
