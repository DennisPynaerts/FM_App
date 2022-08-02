using System;
using System.Collections.Generic;
using System.Text;
using FM_models;

namespace FM_App_DAL.Interfaces
{
    public interface ICarClass
    {
        public bool AddCarToClass(int carId, int classId);
        public bool DeleteCarClass(int carId);
        public IEnumerable<CarClass> GetAllCarsAllClasses();
        public CarClass GetCarClassIdByCarId(int carId);

    }
}
