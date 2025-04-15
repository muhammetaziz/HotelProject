using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityLayer.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPeople { get; set; }
        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Paid"; // Paid, Cancelled, Pending
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<ReservationDetail>? ReservationDetails { get; set; }
    }
}
