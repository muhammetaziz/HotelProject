using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.ReservationDetailDto
{
    public class ReservationDetailAdminDto
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public decimal PricePerNight { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
     
}
