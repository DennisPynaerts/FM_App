using System;
using System.Collections.Generic;
using System.Text;

namespace FM_models
{
    public class Car
    {
		public int id { get; set; }
		public int basePI { get; set; }
		public int hp { get; set; }
		public string model { get; set; }
		public string driveline { get; set; }
		public int buildYear { get; set; }
		public string manufacturer { get; set; }
		public string handling { get; set; }
		public int PI { get; set; }
		public ICollection<CarClass> carClasses { get; set; }

        public Car(string manufacturer, string model, string handling, int PI)
        {
			this.manufacturer = manufacturer;	
			this.model = model;
			this.handling = handling;
			this.PI = PI;
        }

        public Car()
        {

        }

		public override string ToString()
		{
			return $"{handling}H - {manufacturer} {model}";
		}
	}	
}
