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
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(HotelContext context) : base(context)
        {
        }
    }
}
