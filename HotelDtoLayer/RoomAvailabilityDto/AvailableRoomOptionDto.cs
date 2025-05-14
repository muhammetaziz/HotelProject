using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.RoomAvailabilityDto
{
    public class AvailableRoomOptionDto
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
