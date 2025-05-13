using HotelDataAccessLayer.Abstract;
using HotelDataAccessLayer.Concrate;
using HotelDataAccessLayer.Repositories;
using HotelEntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.EntityFramework
{
    public class EfRoomAvailabilityDal : GenericRepository<RoomAvailability>, IRoomAvailabilityDal
    {
        public EfRoomAvailabilityDal(HotelContext context) : base(context)
        {
        }


        public List<RoomAvailability> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            using var context = new HotelContext();
            return context.RoomAvailabilities
                          .Include(x => x.RoomType)
                          .Where(x => x.Date >= startDate && x.Date <= endDate)
                          .ToList();

        }

        public RoomAvailability GetByRoomTypeAndDate(int roomTypeId, DateTime date)
        {
            using var context = new HotelContext();
            return context.RoomAvailabilities.FirstOrDefault(x => x.RoomTypeId == roomTypeId && x.Date.Date == date.Date);
        }
    }
}
