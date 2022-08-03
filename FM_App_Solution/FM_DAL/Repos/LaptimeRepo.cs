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
    public class LaptimeRepo : BaseRepo, ILaptime
    {
        public bool AddLaptime(int carClassId, int trackId, string laptime)
        {
            string sql = @"INSERT INTO FM.dbo.Laptime (carClassId, trackId, laptime)
                           VALUES (@carClassId, @trackId, @laptime)";

            var parameters = new
            {
                @carClassId = carClassId,
                @trackId = trackId,
                @laptime = laptime

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
