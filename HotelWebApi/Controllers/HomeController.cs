using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.HomeDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly IMapper _mapper;

        public HomeController(IHomeService homeService, IMapper mapper)
        {
            _homeService = homeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListHome()
        {
            var values = _mapper.Map<List<ResultHomeDto>>(_homeService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateHome(CreateHomeDto createHomeDto)
        {
            _homeService.TInsert(new Home()
            {
                Description = createHomeDto.Description,
                Title = createHomeDto.Title,
                Image1 = createHomeDto.Image1,
                Image2 = createHomeDto.Image2,
                Image3 = createHomeDto.Image3,
                Image4 = createHomeDto.Image4

            });
            return Ok("Ana sayfa başarılı bir şekilde eklendi.");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteHome(int id)
        {
            var values = _homeService.TGetById(id);
            _homeService.TDelete(values);
            return Ok("Seçili ana sayfa başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateHome(UpdateHomeDto updateHomeDto)
        {
              
            _homeService.TUpdate(new Home()
            {
                Id=updateHomeDto.Id,
                Description = updateHomeDto.Description,
                Title = updateHomeDto.Title,
                Image1 = updateHomeDto.Image1,
                Image2 = updateHomeDto.Image2,
                Image3 = updateHomeDto.Image3,
                Image4 = updateHomeDto.Image4

            });
            return Ok("Seçili ana sayfa başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _homeService.TGetById(id);
            if (values == null)
            {
                return NotFound("Ana sayfa bulunamadı.");
            }
            var result = _mapper.Map<ResultHomeDto>(values);
            return Ok(result);
        }
    }
}
