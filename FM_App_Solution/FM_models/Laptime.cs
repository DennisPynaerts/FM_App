using System;
using System.Collections.Generic;
using System.Text;

namespace FM_models
{
    public class Laptime
    {
        public int id { get; set; }
        public int carClassId { get; set; }
        public int trackId { get; set; }
        public string laptime { get; set; }
        public CarClass carClass { get; set; }
        public Track track { get; set; }    

        public override string ToString()
        {
            return laptime;
        }
    }
}
