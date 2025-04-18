using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.HotelServDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelServController : ControllerBase
    {

        private readonly IHotelServService _hotelServService;
        private readonly IMapper _mapper;

        public HotelServController(IHotelServService hotelServService, IMapper mapper)
        {
            _hotelServService = hotelServService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var hotelServs = _hotelServService.TGetListAll();
            return Ok(hotelServs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hotelServ = _hotelServService.TGetById(id);
            if (hotelServ == null)
            {
                return NotFound();
            }
            return Ok(hotelServ);
        }
        [HttpPost]
        public IActionResult CreateHotelServ(CreateHotelServDto createHotelServDto)
        {
            _hotelServService.TInsert(new HotelServ()
            {
                ActivityDescription = createHotelServDto.ActivityDescription,
                ActivityIcon = createHotelServDto.ActivityIcon,
                ActivityTitle = createHotelServDto.ActivityTitle
            });
            return Ok("Hotel servisleri başarıyla eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hotelServ = _hotelServService.TGetById(id);
            if (hotelServ == null)
            {
                return NotFound();
            }
            _hotelServService.TDelete(hotelServ);
            return Ok("Hotel servisleri başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateHotelServ(UpdateHotelServDto updateHotelServDto)
        {
            _hotelServService.TUpdate(new HotelServ()
            {
                Id = updateHotelServDto.Id,
                ActivityDescription = updateHotelServDto.ActivityDescription,
                ActivityIcon = updateHotelServDto.ActivityIcon,
                ActivityTitle = updateHotelServDto.ActivityTitle,
            });
            return Ok("Hotel Servis bilgileri güncellendi.");
        }
    }
}
