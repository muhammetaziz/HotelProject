using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityLayer.Entities
{
    public class ReservationDetail
    {
        public int ReservationDetailId { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;

        public int Quantity { get; set; } // Kaç tane odayı rezerve etti
        public decimal SubTotal { get; set; } // Bu oda tipinden toplam tutar
    }
}
