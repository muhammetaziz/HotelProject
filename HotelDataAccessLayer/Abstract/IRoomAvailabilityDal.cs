using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.Abstract
{
    public interface  IRoomAvailabilityDal:IGenericDal<RoomAvailability>
    {
        List<RoomAvailability> GetByDateRange(DateTime startDate, DateTime endDate);
        RoomAvailability GetByRoomTypeAndDate(int roomTypeId, DateTime date);
    }
}
