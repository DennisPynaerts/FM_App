using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using FM_App_DAL.Interfaces;
using FM_models;

namespace FM_App_DAL.Repos
{
    public class CarRepo : BaseRepo, ICar
    {
        public bool AddCar(Car car)
        {
            string sql = @"INSERT INTO FM.dbo.Car (manufacturer, model, handling, PI)
                           VALUES (@manufacturer, @model, @handling, @PI)";

            var parameters = new
            {                
                @manufacturer = car.manufacturer,
                @model = car.model,
                @handling = car.handling,
                @PI = car.PI
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var affectedRows = db.Execute(sql, parameters);
                if (affectedRows == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DeleteCar(int id)
        {
            string sql = @"DELETE 
                           FROM FM.dbo.Car 
                           WHERE id = @id";

            var parameters = new
            {
                id = id
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var affectedRows = db.Execute(sql, parameters);
                if (affectedRows >= 1)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Car> GetAllCars()
        {
            string sql = @"SELECT * FROM FM.dbo.Car ORDER BY manufacturer";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Car>(sql);
            }
        }

        public int GetIdFromNewestCar()
        {
            string sql = @"SELECT MAX(id)";
            sql += " FROM FM.dbo.Car";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<int>(sql);
            }
        }

        public static ICollection<CarClass> GroupCarClasses(IEnumerable<CarClass> carClasses)
        {
            return carClasses.GroupBy(cc => cc.id).Select(g =>
            {
                CarClass cc = g.First();
                cc.car = g.Select(c => c.car).Single();
                cc.@class = g.Select(a => a.@class).Single();
                return cc;
            }).ToList();
        }

        public static ICollection<Car> GroupCars(IEnumerable<Car> cars)
        {
            return cars.GroupBy(c => c.id).Select(g =>
            {
                Car car = g.First();
                car.carClasses = g.Select(c => c.carClasses.Single()).ToList();
                return car;
            }).ToList();
        }

        public IEnumerable<Car> GetCarsByClass(int classId)
        {
            var sql = @"SELECT C.*, '' AS SplitCol, CC.*, '' AS SplitCol, Cl.*
                        FROM FM.dbo.Car C
                        JOIN FM.dbo.CarClass CC on CC.carId = C.id
                        JOIN FM.dbo.Class Cl on CC.classId = Cl.id
                        WHERE Cl.id = @classId
                        ORDER BY C.manufacturer";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var cars = db.Query<Car, CarClass, Class, Car>(
                    sql,
                    (car, carClass, @class) =>
                    {
                        car.carClasses = new List<CarClass>() { carClass };
                        return car;
                    },
                    new { classId = classId },
                    splitOn: "SplitCol"
                );
                var groupedCars = GroupCars(cars);
                foreach (var f in groupedCars)
                {
                    f.carClasses = GroupCarClasses(f.carClasses);
                }
                return groupedCars;
            }
        }
    }
}
