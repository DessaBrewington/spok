using System;

namespace ConsoleApp1
{
    //Forecast is the publisher here.  When bad weather happens, it should "tell" whoever is paying attention that something happened.
    public class Forecast
    {
        public int code { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public int high { get; set; }
        public int low { get; set; }
        public string _text { get; set; }

        public string text
        {
            get
            {
                onBadWeather();
                
                return _text;
            }
            set
            {
                _text = value;
                //Other bad weathers would have gone here had I gotten "snow" to trigger properly
                if (_text == "Snow")
                {
                    onBadWeather();
                }
            }
        }
        

        public event EventHandler<BadWeatherEventArgs> badWeather;

        //This definitely pops when "snow" or any other valid test phrase occurs, but .Invoke doesn't seem to do anything.  Does the subscriber not regonize that the event triggered?
        protected virtual void onBadWeather()
        {
            badWeather?.Invoke(this, new BadWeatherEventArgs(this));
        }

    }
}