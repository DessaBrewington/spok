using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Session
    {
        public List<string> messages { get; set; }
        public List<Forecast> forecasts { get; set; }

        public Session()
        {
            forecasts = new List<Forecast>();

            foreach (var forecast in forecasts)
            {
                //This should subscribe handlebadweather to events published by forecast.badweather (which will occur on getForecast below), but it doesnt seem to hear when
                //Forecast pusblishes.
                forecast.badWeather += handleBadWeather;
            }
            DTO dto = new DTO();
            messages = new List<string>();

            //This calls the setter in forecast, and is currently the only time a bad weather event can happen. It does sucessfully trigger events to publish.
            forecasts = dto.getForecast("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29%20where%20text%3D%22Chicago%22%29&amp;format=json&amp;env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");

            //I put the UI here for testing purposes.  If I was continuing this, I'd later set up a separate view class or classes to maintain separation of concerns.  
            //Returning messages back to main seems like a good idea.  
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }

        //This doesn't trigger.  forecast just doesn't pick up on the event that pusblishes, and I'm not sure why.
        private void handleBadWeather(object sender, BadWeatherEventArgs bweArgs)
        {
            messages.Add("Testing: " + bweArgs.text);
        }
    }
}
