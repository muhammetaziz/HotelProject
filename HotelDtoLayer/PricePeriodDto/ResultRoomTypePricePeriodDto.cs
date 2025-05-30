using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.PricePeriodDto
{
    public class ResultRoomTypePricePeriodDto
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }  // İsteğe bağlı: View tarafında gösterim için
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SpecialPricePerNight { get; set; }
    }
}
