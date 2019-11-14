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
    public class FilmDataService
    {
        public static async Task<Films> GetStarWarsFilm(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            Films data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Films>(response);
            }
            return data;
        }
    }
}
