using HotelBusinessLayer.Abstract;
using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.Seeders
{
    public class RoomAvailabilityJob
    {
        private readonly IRoomAvailabilityService _roomAvailabilityService;

        public RoomAvailabilityJob(IRoomAvailabilityService roomAvailabilityService)
        {
            _roomAvailabilityService = roomAvailabilityService;
        }

        public void CreateTomorrowAvailability()
        {
            var roomTypes = _roomAvailabilityService.GetAllRoomTypes();
            var tomorrow = DateTime.Now.Date.AddDays(1);

            foreach (var roomType in roomTypes)
            {
                if (!_roomAvailabilityService.Exists(roomType.RoomTypeId, tomorrow))
                {
                    _roomAvailabilityService.TInsert(new RoomAvailability
                    {
                        RoomTypeId = roomType.RoomTypeId,
                        Date = tomorrow,
                        IsAvailableForSale = true,
                        RemainingQuota = roomType.AvailableRoomCount,
                    });
                }
            }
        }
    }
}
