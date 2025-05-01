namespace HotelWebUI.Dtos.ReservationDtos
{
    public class ReservationSummaryDto
    {
         
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            public int RoomTypeId { get; set; }
            public string RoomTypeName { get; set; }
            public int Quantity { get; set; }

            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int TotalPeople { get; set; }

            public decimal PricePerNight { get; set; }
            public decimal TotalPrice { get; set; }
        

    }
}
