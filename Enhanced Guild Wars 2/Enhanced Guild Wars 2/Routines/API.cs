using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enhanced_Guild_Wars_2.Entities;
using Newtonsoft.Json;

namespace Enhanced_Guild_Wars_2.Routines
{
    public class API
    {
        public static T getScalarValue<T>(string url)
        { 
            using (var webClient = new System.Net.WebClient())
            {
                webClient.Headers.Add("Content-Type", "text");
                webClient.Headers[System.Net.HttpRequestHeader.Authorization] = "Bearer " + Concrete.Constants.Account.apiKey;

                var response = webClient.DownloadString(url);

                var result = JsonConvert.DeserializeObject<T>(response);

                return result;
            }
        }

        public static IList<T> getNonScalarValue<T>(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                webClient.Headers.Add("Content-Type", "text");
                webClient.Headers[System.Net.HttpRequestHeader.Authorization] = "Bearer " + Concrete.Constants.Account.apiKey;

                var response = webClient.DownloadString(url);

                var result = JsonConvert.DeserializeObject<List<T>>(response);

                return result;

            }
        }
    }
}
