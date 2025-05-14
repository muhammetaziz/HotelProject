namespace HotelWebUI.Dtos.RoomAvailablilityDtos
{
    public class AvailableRoomDto
    {
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; } // Gecelik fiyat
        public int AvailableRoomCount { get; set; } // Şu an müsait kaç tane var
    }
}
