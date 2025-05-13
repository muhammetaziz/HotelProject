namespace HotelWebUI.Dtos.RoomAvailablilityDtos
{
    public class RoomAvailabilityTableViewModel
    {
        public List<DateTime> Dates { get; set; }
        public List<RoomAvailabilityRowViewModel> RoomTypes { get; set; }
    }

    public class RoomAvailabilityRowViewModel
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public List<RoomAvailabilityCellViewModel> AvailabilityPerDate { get; set; }
    }

    public class RoomAvailabilityCellViewModel
    {
        public DateTime Date { get; set; }
        public int RemainingQuota { get; set; }
        public int SoldQuota { get; set; }
        public bool IsAvailableForSale { get; set; }
    }
}
