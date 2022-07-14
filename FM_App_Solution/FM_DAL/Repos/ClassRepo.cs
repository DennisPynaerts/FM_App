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
    public class ClassRepo : BaseRepo, IClass
    {
        public IEnumerable<Class> GetClasses()
        {
            string sql = @"SELECT * FROM FM.dbo.Class ORDER BY id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Class>(sql);
            }
        }
    }
}
