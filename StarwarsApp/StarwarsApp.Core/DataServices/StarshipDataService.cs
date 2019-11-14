using Newtonsoft.Json;
using StarwarsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsApp.Core
{
    public class StarshipDataService
    {
        public static async Task<Starships> GetStarWarsStarship(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            Starships data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Starships>(response);
            }
            return data;
        }
    }
}
