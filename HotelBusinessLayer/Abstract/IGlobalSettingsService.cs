﻿using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer.Abstract
{
    public  interface IGlobalSettingsService
    {
        GlobalSettings GetSettings();
        void UpdateSettings(GlobalSettings settings);
    }
}
