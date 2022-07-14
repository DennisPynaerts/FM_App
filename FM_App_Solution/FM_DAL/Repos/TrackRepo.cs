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
    public class TrackRepo : BaseRepo, ITrack
    {
        public IEnumerable<Track> GetAllTracksWithWeatherSetting()
        {
            var sql = @"SELECT T.*, '' AS SplitCol, W.*
                        FROM FM.dbo.Track T
                        JOIN FM.dbo.Weather W ON T.weatherId = W.id
                        ORDER BY T.name";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Track, Weather, Track>(
                    sql,
                    (track, weather) =>
                    {
                        track.weather = weather;
                        return track;
                    },
                    splitOn: "SplitCol"
                );
            }
        }
    }
}
