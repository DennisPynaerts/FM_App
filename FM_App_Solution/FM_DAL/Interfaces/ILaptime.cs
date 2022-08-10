using System;
using System.Collections.Generic;
using System.Text;
using FM_models;

namespace FM_App_DAL.Interfaces
{
    public interface ILaptime
    {
        public bool AddLaptime(int carClassId, int trackId, string laptime);
        public int GetLaptimeByCarClassIdAndTrackId(int carClassId, int trackId);
        public string GetLaptimeByTrackAndCarId(int carClassId, int trackId);
        public bool UpdateLaptime(int carClassId, int trackId, string laptime);
        public IEnumerable<Laptime> GetAllLaptimesByTrackId(int trackId);
    }
}
