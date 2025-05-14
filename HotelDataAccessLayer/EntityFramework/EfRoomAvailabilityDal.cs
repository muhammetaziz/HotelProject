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

        public List<RoomType> GetAvailableRoomTypes(DateTime checkIn, DateTime checkOut, int personCount)
        {
            using var context = new HotelContext();

            var availableRoomTypes = context.RoomAvailabilities
                .Include(x => x.RoomType)
                .Where(x => x.Date >= checkIn && x.Date < checkOut)
                .Where(x => x.IsAvailableForSale && x.RemainingQuota > 0)
                .GroupBy(x => x.RoomTypeId)
                .Where(g => g.Count() == (checkOut - checkIn).Days) // her gün için müsaitlik var mı
                .Select(g => g.First().RoomType)
                .Where(rt => rt.Capacity >= personCount)
                .Distinct()
                .ToList();

            return availableRoomTypes;
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
            return context.RoomAvailabilities.Include(x => x.RoomType).FirstOrDefault(x => x.RoomTypeId == roomTypeId && x.Date.Date == date.Date);
        }
        public List<RoomAvailability> GetByRoomTypeAndDateRange(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            using var context = new HotelContext();
            return context.RoomAvailabilities
                          .Include(x => x.RoomType)
                          .Where(x => x.RoomTypeId == roomTypeId && x.Date >= startDate && x.Date < endDate)
                          .ToList();
        }
    }
}
