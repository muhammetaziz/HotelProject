using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.RoomTypeDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IMapper _mapper;

        public RoomTypeController(IRoomTypeService roomTypeService, IMapper mapper)
        {
            _roomTypeService = roomTypeService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ListRoomType()
        {
            var values = _mapper.Map<List<ResultRoomTypeDto>>(_roomTypeService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateRoomType(CreateRoomTypeDto createRoomTypeDto)
        {
            _roomTypeService.TInsert(new RoomType
            {
                Capacity = createRoomTypeDto.Capacity,
                PricePerNight = createRoomTypeDto.PricePerNight,
                AvailableRoomCount = createRoomTypeDto.AvailableRoomCount,
                Description = createRoomTypeDto.Description,

            });
            return Ok("Oda tipi başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoomType(int id)
        {
            var values = _roomTypeService.TGetById(id);
            if (values == null)
            {
                return NotFound("Oda tipi bulunamadı.");
            }
            _roomTypeService.TDelete(values);
            return Ok("Oda tipi silindi.");
        }
        [HttpPut]
        public IActionResult UpdateRoomType(UpdateRoomTypeDto updateRoomTypeDto)
        {
            _roomTypeService.TUpdate(new RoomType
            {
                Capacity = updateRoomTypeDto.Capacity,
                PricePerNight = updateRoomTypeDto.PricePerNight,
                AvailableRoomCount = updateRoomTypeDto.AvailableRoomCount,
                Description = updateRoomTypeDto.Description,

            });
            return Ok("Oda tipi başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetRoomType(int id)
        {
            var values = _roomTypeService.TGetById(id);
            var result = _mapper.Map<ResultRoomTypeDto>(values);
            return Ok(result);
        }
    }
}
