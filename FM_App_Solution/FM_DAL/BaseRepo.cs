using System;
using System.Collections.Generic;
using System.Text;

namespace FM_App_DAL
{
    public abstract class BaseRepo
    {
        protected string ConnectionString { get; }

        public BaseRepo()
        {
            ConnectionString = DatabaseConnection.Connectionstring("FM");
        }
    }
}
