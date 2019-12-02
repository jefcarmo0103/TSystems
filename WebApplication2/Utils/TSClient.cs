using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public class TSClient
    {
        private static string url = "http://177.36.237.87";
        private static HttpClient client = new HttpClient();

        public static async Task<List<Lutador>> GetAllFighters()
        {
            initClient();

            List<Lutador> lutadores = new List<Lutador>();

            var task = client.GetAsync("/lutadores/api/competidores")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var json = response.Content.ReadAsStringAsync();
                    json.Wait();
                   lutadores = JsonConvert.DeserializeObject<List<Lutador>>(json.Result);
                });
            task.Wait();
                
            return lutadores;
        }

        private static void initClient()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        
    }
}