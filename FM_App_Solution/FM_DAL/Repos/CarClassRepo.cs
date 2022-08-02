using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using FM_App_DAL.Interfaces;
using FM_models;

namespace FM_App_DAL.Repos
{
    public class CarClassRepo : BaseRepo, ICarClass
    {
        public bool AddCarToClass(int carId, int classId)
        {
            string sql = @"INSERT INTO FM.dbo.CarClass (carId, classId)
                           VALUES (@carId, @classId)";

            var parameters = new
            {
                @carId = carId,
                @classId = classId
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

        public bool DeleteCarClass(int carId)
        {
            string sql = @"DELETE FROM FM.dbo.CarClass 
                           WHERE carId = @carId";

            var parameters = new
            {
                @carId = carId
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

        public IEnumerable<CarClass> GetAllCarsAllClasses()
        {
            var sql = @"SELECT CC.*, '' AS SplitCol, C.*
                        FROM FM.dbo.CarClass CC
                        JOIN FM.dbo.Car C ON CC.carId = C.id
                        ORDER BY C.manufacturer";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<CarClass, Car, CarClass>(
                    sql,
                    (carClass, car) =>
                    {
                        carClass.carId = car.id;
                        return carClass;
                    },
                    splitOn: "SplitCol"
                );
            }
        }
    }
}
