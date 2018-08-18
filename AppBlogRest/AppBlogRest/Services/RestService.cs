using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace AppBlogRest.Services
{
    public class RestService<T>
    {
        private HttpClient _client = new HttpClient();
        
        public async Task<List<T>> GetAsync(string entity)
        {
            try
            {
                string url = string.Format($"http://jsonplaceholder.typicode.com/{entity}");

                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new List<T>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<T>>(content);
                    return new List<T>(list);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAsync(string entity, int id)
        {
            try
            {
                string url = string.Format($"http://jsonplaceholder.typicode.com/{entity}/{id}");

                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new List<T>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<T> list = new List<T>();
                    list.Add(JsonConvert.DeserializeObject<T>(content));
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
