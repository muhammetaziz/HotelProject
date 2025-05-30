using Newtonsoft.Json;

namespace HotelWebUI.Dtos.SpecialPriceDtos
{
    public class SpecialPriceDto
    {
        public int SpecialPriceId { get; set; }
        public int RoomTypeId { get; set; } 
        public string RoomTypeName { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [JsonProperty("specialPricePerNight")] 
        public decimal SpecialPrice { get; set; }
    }
}
