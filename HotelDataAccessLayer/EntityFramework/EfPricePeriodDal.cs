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
    public class EfPricePeriodDal : GenericRepository<RoomTypePricePeriod>, IPricePeriodDal
    {
        public EfPricePeriodDal(HotelContext context) : base(context)
        {
        }
        public List<RoomTypePricePeriod> GetSpecialPriceListWithRoomType()
        {
            using (var context = new HotelContext()) // örn: HotelContext
            {
                return context.RoomTypePricePeriods
                    .Include(x => x.RoomType)
                    .ToList();
            }
        }

        public async Task<bool> IsOverlappingAsync(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            using (var context = new HotelContext())
            {

                return await context.RoomTypePricePeriods.AnyAsync(x =>
                    x.RoomTypeId == roomTypeId &&
                    (
                        (startDate >= x.StartDate && startDate <= x.EndDate) ||
                        (endDate >= x.StartDate && endDate <= x.EndDate) ||
                        (startDate <= x.StartDate && endDate >= x.EndDate)
                    ));
            }
        }
    }
}


