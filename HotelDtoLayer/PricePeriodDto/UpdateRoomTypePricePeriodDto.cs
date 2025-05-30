using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.PricePeriodDto
{
    public class UpdateRoomTypePricePeriodDto
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SpecialPricePerNight { get; set; }
    }
}
