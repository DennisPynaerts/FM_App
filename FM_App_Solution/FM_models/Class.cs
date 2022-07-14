using System;
using System.Collections.Generic;
using System.Text;

namespace FM_models
{
    public class Class
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxPI { get; set; }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
