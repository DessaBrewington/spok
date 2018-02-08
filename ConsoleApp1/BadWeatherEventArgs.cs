using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BadWeatherEventArgs : EventArgs
    {
        public string date { get; private set; }
        public string day { get; private set; }
        public int high { get; private set; }
        public int low { get; private set; }
        public string text { get; private set; }

        public BadWeatherEventArgs(Forecast forecast)
        {
            this.date = forecast.date;
            this.day = day;
            this.high = high;
            this.low = low;
            this.text = text;
        }
    }
}
