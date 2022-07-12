using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FM_App_DAL
{
    public static class DatabaseConnection
    {
        public static string Connectionstring(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
