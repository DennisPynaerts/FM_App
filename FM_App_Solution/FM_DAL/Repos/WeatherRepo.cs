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
    public class WeatherRepo : BaseRepo, IWeather
    {
        public IEnumerable<Weather> GetAllWeatherSettings()
        {
            string sql = "SELECT [name] FROM Weather ORDER BY [name]";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Weather>(sql);
            }
        }
    }
}
