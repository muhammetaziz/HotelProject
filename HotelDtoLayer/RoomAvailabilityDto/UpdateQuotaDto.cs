using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.RoomAvailabilityDto
{
    public class UpdateQuotaDto
    {
        public int RoomTypeId { get; set; }
        public DateTime Date { get; set; }
        public int Quota { get; set; }
    }
}
