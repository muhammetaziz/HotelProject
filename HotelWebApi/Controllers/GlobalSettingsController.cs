using HotelBusinessLayer.Abstract;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalSettingsController : ControllerBase
    {
        private readonly IGlobalSettingsService _globalSettingsService;

        public GlobalSettingsController(IGlobalSettingsService globalSettingsService)
        {
            _globalSettingsService = globalSettingsService;
        }

        [HttpGet]
        public IActionResult GetSettings()
        {
            var settings = _globalSettingsService.GetSettings();
            return Ok(settings);
        }

        [HttpPut]
        public IActionResult UpdateSettings(GlobalSettings settings)
        {
            _globalSettingsService.UpdateSettings(settings);
            return Ok("Ayarlar güncellendi.");
        }
    }
}
