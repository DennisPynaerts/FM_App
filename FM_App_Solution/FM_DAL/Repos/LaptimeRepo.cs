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

        public IEnumerable<Laptime> GetAllLaptimesByTrackId(int trackId)
        {
            var sql = @"SELECT L.*, '' AS SplitCol, CC.*, '' AS SplitCol, T.*, '' AS SplitCol, C.*
                        FROM FM.dbo.Laptime L
                        JOIN FM.dbo.CarClass CC ON L.carClassId = CC.id
                        JOIN FM.dbo.Track T ON L.trackId = T.id
                        JOIN FM.dbo.Car C on CC.carId = C.id
                        WHERE trackId = @trackId
                        ORDER BY L.laptime";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Laptime, CarClass, Track, Car, Laptime>(
                    sql,
                    (Laptime, CarClass, Track, Car) =>
                    {
                        Laptime.carClass = CarClass;
                        Laptime.track = Track;
                        Laptime.carClass.car = Car;
                        Laptime.trackId = @trackId;
                        return Laptime;
                    },
                    new { @trackId = trackId },
                    splitOn: "SplitCol"
                );
            }
        }

        public int GetLaptimeByCarClassIdAndTrackId(int carClassId, int trackId)
        {
            string sql = @"SELECT L.id";
            sql += " FROM FM.dbo.Laptime L";
            sql += " WHERE carClassId = @carClassId AND trackId = @trackId";

            var parameters = new { @carClassId = carClassId, @trackId = trackId };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<int>(sql, parameters);
            }
        }

        public string GetLaptimeByTrackAndCarId(int carClassId, int trackId)
        {
            string sql = @"SELECT L.laptime";
            sql += " FROM FM.dbo.Laptime L";
            sql += " WHERE carClassId = @carClassId AND trackId = @trackId";

            var parameters = new { @carClassId = carClassId, @trackId = trackId };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<string>(sql, parameters);
            }
        }

        public bool UpdateLaptime(int carClassId, int trackId, string laptime)
        {
            string sql = @"UPDATE FM.dbo.Laptime SET laptime = @laptime
                          WHERE carClassId = @carClassId AND trackId = @trackId";

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
