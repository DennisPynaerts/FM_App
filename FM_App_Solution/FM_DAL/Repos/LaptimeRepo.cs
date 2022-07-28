using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM_App_DAL.Interfaces;
using FM_models;

namespace FM_App_DAL.Repos
{
    public class LaptimeRepo : BaseRepo, ILaptime
    {
        public bool AddLaptime(int carClassId, int trackId, string laptime)
        {
            throw new NotImplementedException();
        }
    }
}
