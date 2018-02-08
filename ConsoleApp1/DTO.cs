using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class DTO
    {
        public List<Forecast> getForecast(string URL)
        {
            StringBuilder address = new StringBuilder();
            address.Append("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29%20where%20text%3D%22Chicago%22%29&amp;format=json&amp;env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            address.Append("&format=json");

            //Fetch results from address URL
            string result = "";
            using (WebClient wc = new WebClient())
            {
                result = wc.DownloadString(address.ToString());
            }

            //Parse and package
            JObject jsonObject = JObject.Parse(result);
            JToken jsonToken = jsonObject["query"]["results"]["channel"]["item"];
            //This contains the weather forecast, along with location information.
            Item item = jsonToken.ToObject<Item>();

            return item.forecast;
        }


    }
}
