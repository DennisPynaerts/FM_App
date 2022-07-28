using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using FM_App_DAL.Interfaces;

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
    }
}
