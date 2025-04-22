namespace HotelWebUI.Dtos.RoomTypeDtos
{
    public class ResultRoomTypeDto
    {
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; } // Kaç kişilik
        public decimal PricePerNight { get; set; } // Gecelik fiyat
        public int AvailableRoomCount { get; set; } // Şu an müsait kaç tane var
        public string Description { get; set; }
    }
}
