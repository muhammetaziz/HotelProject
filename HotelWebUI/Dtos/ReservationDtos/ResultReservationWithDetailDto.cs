namespace HotelWebUI.Dtos.ReservationDtos
{
    public class ResultReservationWithDetailDto
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

        public List<ReservationDetailDto> ReservationDetails { get; set; }
    }

    public class ReservationDetailDto
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public decimal PricePerNight { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
