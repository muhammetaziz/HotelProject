namespace HotelWebUI.Dtos.ReservationDtos
{
    public class ReservationInfoDto
    {
        public int RoomTypeId { get; set; }
        public int Quantity { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPeople { get; set; }

        // Kişisel bilgiler
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
