namespace HotelWebUI.Dtos.RoomTypeDtos
{
    public class ResultRoomTypeDto
    {
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public string ExistingImageUrl { get; set; } // ✅ Burası olmalı
        public int AvailableRoomCount { get; set; } // Şu an müsait kaç tane var
    }
}
