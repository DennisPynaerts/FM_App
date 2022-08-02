using System;
using System.Collections.Generic;
using System.Text;

namespace FM_models
{
    public class CarClass
    {
        public int id { get; set; }
        public int carId { get; set; }
        public int classId { get; set; }
        public Car car { get; set; }
        public Class @class { get; set; } 
        public ICollection<Car> cars { get; set; }
    }
}
