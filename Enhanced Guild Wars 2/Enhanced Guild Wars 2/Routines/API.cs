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

        public static List<T> getNonScalarValue<T>(string url)
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

        public static List<string> getURLsWithIdsList(string url, List<int> ids)
        {
            List<string> urls = new List<string>();

            int itemCount = ids.Count();
            int skipIndex = 0;
            int takeIndex = 0;

            if (itemCount < 200)
            {
                takeIndex = ids.Count();
            }
            else
            {
                takeIndex = 200;
            }

            for (int i = 0; i <= itemCount;)
            {
                string idQuery = String.Join(",", ids.Skip(skipIndex).Take(takeIndex));

                string URLandIds = String.Format("{0}{1}", url, idQuery);

                urls.Add(URLandIds);

                i += 200;

                if ((i + 200) >= itemCount)
                {
                    takeIndex = itemCount - i;
                    skipIndex += 200;
                }
                else
                {
                    takeIndex = 200;
                    skipIndex += 200;
                }
            }

            return urls;
        }
    }
}
