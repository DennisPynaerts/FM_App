﻿using System;
using System.Collections.Generic;
using System.Text;
using FM_models;

namespace FM_App_DAL.Interfaces
{
    public interface IClass
    {
        public IEnumerable<Class> GetClasses(); 
    }
}
