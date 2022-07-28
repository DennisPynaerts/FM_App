using System;
using System.Collections.Generic;
using System.Text;
using FM_models;

namespace FM_App_DAL.Interfaces
{
    public interface ICar
    {
        public IEnumerable<Car> GetAllCars();
        public bool AddCar(Car car);
        public bool DeleteCar(int id);
        public int GetIdFromNewestCar();
        public IEnumerable<Car> GetCarsByClass(int classId);
    }
}
