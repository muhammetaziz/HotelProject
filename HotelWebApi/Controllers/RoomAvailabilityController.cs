using HotelBusinessLayer.Abstract;
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

        public RoomAvailabilityController(IRoomAvailabilityService roomAvailabilityService)
        {
            _roomAvailabilityService = roomAvailabilityService;
        }

        [HttpGet("GetAvailability")]
        public IActionResult GetAvailability(DateTime startDate, DateTime endDate)
        {
            var data = _roomAvailabilityService.GetByDateRange(startDate, endDate);
            return Ok(data);
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
    }
}
