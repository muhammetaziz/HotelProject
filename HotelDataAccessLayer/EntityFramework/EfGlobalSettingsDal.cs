using HotelDataAccessLayer.Abstract;
using HotelDataAccessLayer.Concrate;
using HotelDataAccessLayer.Repositories;
using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.EntityFramework
{
    public class EfGlobalSettingsDal:GenericRepository<GlobalSettings>, IGlobalSettingsDal
    {

        public EfGlobalSettingsDal(HotelContext context) : base(context)
        {
        }
    }
}
