namespace HotelWebUI.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPeople { get; set; }

        public List<ResultReservationDetailDto> resultReservationDetailDtos { get; set; }
    }
}
