namespace HotelWebUI.Dtos.ReservationDtos
{
    public class AdmınReservationListDto
    {
            public int ReservationId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int TotalPeople { get; set; }
            public decimal TotalPrice { get; set; }
            public string Status { get; set; }
            public DateTime CreatedDate { get; set; }
            //public string ReservationCode { get; set; } // opsiyonel alan

    }
}
