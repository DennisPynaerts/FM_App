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

        public IEnumerable<Car> GetAllCars()
        {
            string sql = @"SELECT * FROM FM.dbo.Car ORDER BY manufacturer";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Car>(sql);
            }
        }
    }
}
