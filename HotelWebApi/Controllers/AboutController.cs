using HotelBusinessLayer.Abstract;
using HotelDtoLayer.AboutDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult ListAbout()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                AboutDescription = createAboutDto.AboutDescription,
                Image1 = createAboutDto.Image1,
                Image2 = createAboutDto.Image2,
                Image3 = createAboutDto.Image3
            };
            _aboutService.TInsert(about);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok("Seçili hakkımda kısmı başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var values = _aboutService.TGetById(updateAboutDto.AboutId);

            values.AboutDescription = updateAboutDto.AboutDescription;
            values.Image1 = updateAboutDto.Image1;
            values.Image2 = updateAboutDto.Image2;
            values.Image3 = updateAboutDto.Image3;
            _aboutService.TUpdate(values);
            return Ok("Seçili hakkımda kısmı başarılı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
             var values = _aboutService.TGetById(id);
            return Ok(values);
        }
    }
}
