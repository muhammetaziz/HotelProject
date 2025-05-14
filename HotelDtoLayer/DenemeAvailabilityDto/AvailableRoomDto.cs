using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.DenemeAvailabilityDto
{
    public class AvailableRoomDto
    {
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
    }
}
