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
        bool Exists(int roomTypeId, DateTime date);
        List<RoomType> GetAllRoomTypes();
        public List<RoomType> GetAvailableRoomTypes(DateTime checkIn, DateTime checkOut, int personCount);
        public List<RoomAvailability> GetByRoomTypeAndDateRange(int roomTypeId, DateTime startDate, DateTime endDate);

    }
}
    