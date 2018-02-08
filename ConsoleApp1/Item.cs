using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Named this "item" to match the names given by yahoo's API to a weather forecast.
    public class Item
    {
        public string title { get; set; }
        public double lat { get; set; }
        public double @long { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public Condition condition { get; set; }
        public List<Forecast> forecast { get; set; }
        public string description { get; set; }
        //public string guid { get; set; }

        
    }
}
