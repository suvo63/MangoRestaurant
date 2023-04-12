using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            var client = _httpClient.CreateClient("MangoAPI");
            var message= new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri= new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if(apiRequest.Data!=null){
                message.Content= new StringContent(JsonSerializer.Serialize(apiRequest.Data),
                Encoding.UTF8,"application/json");
            }

            HttpResponseMessage apiResponse= null;
            switch(apiRequest.ApiType){
                case SD.ApiType.GET:
                    message.Method=HttpMethod.Get;
                    break;
                case SD.ApiType.POST:
                    message.Method=HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method=HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method=HttpMethod.Delete;
                    break;
            }
            apiResponse= await client.SendAsync(message);
            
            return JsonSerializer.Deserialize<T>(await apiResponse.Content.ReadAsStringAsync());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}