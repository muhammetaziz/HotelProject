using System.ComponentModel.DataAnnotations;

namespace HotelWebUI.Dtos.ReservationDtos
{
    public class ReservationSearchDto
    {
        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int AdultCount { get; set; }

        //public int ChildCount { get; set; }
    }
}
