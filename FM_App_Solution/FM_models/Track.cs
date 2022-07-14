using System;
using System.Collections.Generic;
using System.Text;

namespace FM_models
{
    public class Track
    {
        public int id { get; set; }
        public string name { get; set; }
        public int weatherId { get; set; }
        public Weather weather { get; set; }

        public override string ToString()
        {
            return $"{name} - {weather.name}";
        }
    }    
}
