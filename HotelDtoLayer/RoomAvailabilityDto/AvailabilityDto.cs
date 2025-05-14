namespace HotelDtoLayer.RoomAvailabilityDto
{
    public class AvailabilityDto
    {
        public int RoomTypeId { get; set; }
        public DateTime Date { get; set; }
        public int RemainingQuota { get; set; }
        public bool IsAvailableForSale { get; set; }
        public string RoomTypeName { get; set; }
    }
}
