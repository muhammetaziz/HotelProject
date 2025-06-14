using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.PricePeriodDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricePeriodController : ControllerBase
    {
        private readonly IPricePeriodService _roomTypePricePeriodService;
        private readonly IMapper _mapper;

        public PricePeriodController(IPricePeriodService roomTypePricePeriodService, IMapper mapper)
        {
            _roomTypePricePeriodService = roomTypePricePeriodService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _roomTypePricePeriodService.TGetSpecialPriceListWithRoomType();
            var result = _mapper.Map<List<ResultRoomTypePricePeriodDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _roomTypePricePeriodService.TGetById(id);
            if (value == null) return NotFound();
            var result = _mapper.Map<ResultRoomTypePricePeriodDto>(value);
            return Ok(result);
        }

         

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoomTypePricePeriodDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Geçersiz veri gönderildi.");

            var isOverlapping = await _roomTypePricePeriodService.IsOverlappingAsync(dto.RoomTypeId, dto.StartDate, dto.EndDate);

            if (isOverlapping)
                return BadRequest("Bu oda tipi için bu tarih aralığında zaten bir özel fiyat tanımı mevcut.");

            var entity = _mapper.Map<RoomTypePricePeriod>(dto);
            await _roomTypePricePeriodService.InsertAsync(entity);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateRoomTypePricePeriodDto dto)
        {
            var entity = _mapper.Map<RoomTypePricePeriod>(dto);
            _roomTypePricePeriodService.TUpdate(entity);
            return Ok("Özel fiyat dönemi güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _roomTypePricePeriodService.TGetById(id);
            if (value == null) return NotFound();
            _roomTypePricePeriodService.TDelete(value);
            return Ok("Özel fiyat dönemi silindi.");
        }
        [HttpGet("CheckOverlap")]
        public async Task<IActionResult> CheckOverlap(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            var isOverlapping = await _roomTypePricePeriodService.IsOverlappingAsync(roomTypeId, startDate, endDate);
            return Ok(isOverlapping);
        }

    }
}
