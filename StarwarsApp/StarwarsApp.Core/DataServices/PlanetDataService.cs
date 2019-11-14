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
    public class PlanetDataService
    {
        public static async Task<Planets> GetStarWarsPlanets(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            Planets data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Planets>(response);
            }
            return data;
        }
    }
}
