using HotelBusinessLayer.Abstract;
using HotelDtoLayer.DenemeAvailabilityDto;
using HotelDtoLayer.RoomAvailabilityDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAvailabilityController : ControllerBase
    {
        private readonly IRoomAvailabilityService _roomAvailabilityService;
        private readonly IRoomTypeService _roomTypeService;

        public RoomAvailabilityController(IRoomAvailabilityService roomAvailabilityService, IRoomTypeService roomTypeService)
        {
            _roomAvailabilityService = roomAvailabilityService;
            _roomTypeService = roomTypeService;
        }

        [HttpGet("GetAvailability")]
        public IActionResult GetAvailability(DateTime startDate, DateTime endDate)
        {
            var data = _roomAvailabilityService.GetByDateRange(startDate, endDate);

            var result = data.Select(x => new AvailabilityDto
            {
                RoomTypeId = x.RoomTypeId,
                Date = x.Date,
                RemainingQuota = x.RemainingQuota,
                IsAvailableForSale = x.IsAvailableForSale,
                RoomTypeName = x.RoomType?.Description // 🔸 Burada geliyor
            }).ToList();

            return Ok(result);
        }
        [HttpPatch("ToggleAvailability")]
        public IActionResult ToggleAvailability([FromBody] ToogleAvailabilityDto dto)
        {
            var availability = _roomAvailabilityService.GetByRoomTypeAndDate(dto.RoomTypeId, dto.Date);
            if (availability == null)
                return NotFound("Müsaitlik kaydı bulunamadı.");

            availability.IsAvailableForSale = dto.IsAvailable;
            _roomAvailabilityService.TUpdate(availability);
            return Ok();
        }
        [HttpPatch("UpdateQuota")]
        public IActionResult UpdateQuota([FromBody] UpdateQuotaDto dto)
        {
            var availability = _roomAvailabilityService.GetByRoomTypeAndDate(dto.RoomTypeId, dto.Date);
            if (availability == null)
                return NotFound("Müsaitlik kaydı bulunamadı.");

            availability.RemainingQuota = dto.Quota;
            _roomAvailabilityService.TUpdate(availability);
            return Ok();
        }
        [HttpPost("CheckRoomAvailability")]
        public IActionResult CheckRoomAvailability([FromBody] AvailabilityCheckRequestDto request)
        {
            var roomTypes = _roomTypeService.TGetListAll(); // Kapasite gibi bilgiler için

            var result = new List<AvailableRoomOptionDto>();

            foreach (var roomType in roomTypes)
            {
                if (roomType.Capacity < request.PersonCount)
                    continue;

                var availabilities = _roomAvailabilityService
                    .GetByRoomTypeAndDateRange(roomType.RoomTypeId, request.StartDate, request.EndDate);

                var isAvailableAllDates = availabilities.All(a => a.IsAvailableForSale && a.RemainingQuota > 0);

                result.Add(new AvailableRoomOptionDto
                {
                    RoomTypeId = roomType.RoomTypeId,
                    RoomTypeName = roomType.Description,
                    Capacity = roomType.Capacity,
                    PricePerNight = roomType.PricePerNight, // varsa
                    IsAvailable = isAvailableAllDates
                });
            }

            var availableRooms = result.Where(x => x.IsAvailable).ToList();

            if (!availableRooms.Any())
                return NotFound("Seçtiğiniz tarihlerde uygun oda bulunamadı.");

            return Ok(availableRooms);
        }
        [HttpPost("SearchAvailableRooms")]
        public IActionResult SearchAvailableRooms([FromBody] RoomAvailabilitySearchDto dto)
        {
            if (dto.CheckOutDate <= dto.CheckInDate)
                return BadRequest("Çıkış tarihi, giriş tarihinden sonra olmalıdır.");

            var availableRoomTypes = _roomAvailabilityService.GetAvailableRoomTypes(dto.CheckInDate, dto.CheckOutDate, dto.PersonCount);

            if (!availableRoomTypes.Any())
            {
                return NotFound("Seçtiğiniz tarihlerde uygun oda bulunmamaktadır.");
            }

            return Ok(availableRoomTypes);
        }
        [HttpPost("CheckAvailability")]
        public IActionResult CheckAvailability([FromBody] CheckAvailabilityRequestDto request)
        {
            var roomTypes = _roomTypeService.TGetListAll(); // Tüm oda tipleri

            var suitableRoomTypes = new List<AvailableRoomDto>();

            foreach (var roomType in roomTypes)
            {
                // İlgili oda tipi için tarihlerdeki tüm müsaitlikler
                var availabilities = _roomAvailabilityService
                    .GetByRoomTypeAndDateRange(roomType.RoomTypeId, request.CheckIn, request.CheckOut);

                // Her gün için müsaitlik var mı ve kontenjan yeterli mi?
                bool isFullyAvailable = availabilities.Count == (request.CheckOut - request.CheckIn).Days &&
                                        availabilities.All(a => a.IsAvailableForSale && a.RemainingQuota > 0);

                if (isFullyAvailable && roomType.Capacity >= request.PersonCount)
                {
                    suitableRoomTypes.Add(new AvailableRoomDto
                    {
                        RoomTypeId = roomType.RoomTypeId,
                        RoomName = roomType.Description,
                        Capacity = roomType.Capacity
                    });
                }
            }

            if (!suitableRoomTypes.Any())
            {
                return NotFound("Seçilen tarih aralığında uygun oda bulunamadı.");
            }

            return Ok(suitableRoomTypes);
        }

    }
}
