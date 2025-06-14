using HotelBusinessLayer.Abstract;
using HotelDataAccessLayer.Abstract;
using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer.Concrete
{
    public class GlobalSettingsManager : IGlobalSettingsService
    {
        private readonly IGlobalSettingsDal _globalSettingsDal;

        public GlobalSettingsManager(IGlobalSettingsDal globalSettingsDal)
        {
            _globalSettingsDal = globalSettingsDal;
        }

        public GlobalSettings GetSettings()
        {
            return _globalSettingsDal.GetListAll().FirstOrDefault();
        }

        public void UpdateSettings(GlobalSettings settings)
        {
            _globalSettingsDal.Update(settings);
        }
    }
}
