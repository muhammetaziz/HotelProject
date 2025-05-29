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
        public async Task<IActionResult> CreateRoomType([FromForm] CreateRoomTypeDto dto)
        {
            string? imageUrl = null;

            if (dto.RoomImage != null && dto.RoomImage.Length > 0)
            {
                var extension = Path.GetExtension(dto.RoomImage.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Rooms/", newFileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await dto.RoomImage.CopyToAsync(stream);
                }

                imageUrl = "/Images/Rooms/" + newFileName;
            }

            var roomType = new RoomType
            {
                Capacity = dto.Capacity,
                PricePerNight = dto.PricePerNight,
                AvailableRoomCount = dto.AvailableRoomCount,
                Description = dto.Description,
                ImageUrl = imageUrl
            };

            _roomTypeService.TInsert(roomType);
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
        public async Task<IActionResult> UpdateRoomType([FromForm] UpdateRoomTypeDto dto)
        {
            var roomType = _roomTypeService.TGetById(dto.RoomTypeId);
            if (roomType == null) return NotFound("Oda tipi bulunamadı.");

            if (dto.RoomImage != null && dto.RoomImage.Length > 0)
            {
                var extension = Path.GetExtension(dto.RoomImage.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Rooms/", newFileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await dto.RoomImage.CopyToAsync(stream);
                }

                roomType.ImageUrl = "/Images/Rooms/" + newFileName;
            }

            roomType.Capacity = dto.Capacity;
            roomType.PricePerNight = dto.PricePerNight;
            roomType.AvailableRoomCount = dto.AvailableRoomCount;
            roomType.Description = dto.Description;

            _roomTypeService.TUpdate(roomType);
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
