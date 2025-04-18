using HotelEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.ReservationDetailDto
{
    public class ResultReservationDetailDto
    {
        public int ReservationDetailId { get; set; }

        public int ReservationId { get; set; }
       

        public int RoomTypeId { get; set; }
        
        public int Quantity { get; set; } // Kaç tane odayı rezerve etti
        public decimal SubTotal { get; set; } // Bu oda tipinden toplam tutar
    }
}
