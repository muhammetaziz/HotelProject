namespace HotelWebUI.Dtos.RoomTypeDtos
{
    public class RoomTypeViewModel
    {
        
            public int RoomTypeId { get; set; }
            public int Capacity { get; set; }
            public decimal PricePerNight { get; set; }
            public int AvailableRoomCount { get; set; }
            public string? Description { get; set; }
            public IFormFile? RoomImage { get; set; }
            public string? ExistingImageUrl { get; set; } // sadece Update için
         

    }
}
