using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.ReservationDetailDto
{
    public class CreateReservationDetailDto
    {
        public int ReservationId { get; set; }
        public int RoomTypeId { get; set; }
        public int Quantity { get; set; } 
        public decimal SubTotal { get; set; } 
    }
}
