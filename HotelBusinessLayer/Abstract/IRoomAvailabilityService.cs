using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer.Abstract
{
    public interface IRoomAvailabilityService:IGenericService<RoomAvailability>
    {
        List<RoomAvailability> GetByDateRange(DateTime startDate, DateTime endDate);
        RoomAvailability GetByRoomTypeAndDate(int roomTypeId, DateTime date);
    }
}
