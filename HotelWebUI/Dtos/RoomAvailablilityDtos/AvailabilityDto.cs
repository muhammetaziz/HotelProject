namespace HotelWebUI.Dtos.RoomAvailablilityDtos
{
    public class AvailabilityDto
    {
        public DateTime Date { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int RemainingQuota { get; set; }
        public bool IsAvailableForSale { get; set; }
    }
}
