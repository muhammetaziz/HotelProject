using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.SocialMediaDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ListSocialMedia()
        {
            var socialMediaList = _socialMediaService.TGetListAll();
            var socialMediaDtoList = _mapper.Map<List<ResultSocialMediaDto>>(socialMediaList);
            return Ok(socialMediaDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            return Ok(socialMedia);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TInsert(new SocialMedia
            {
                Instagram = createSocialMediaDto.Instagram,
                Facebook = createSocialMediaDto.Facebook,
                Twitter = createSocialMediaDto.Twitter
            });
            return Ok("Sosyal medya eklendi.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia
            {
                SocialMediaId = updateSocialMediaDto.SocialMediaId,
                Instagram = updateSocialMediaDto.Instagram,
                Facebook = updateSocialMediaDto.Facebook,
                Twitter = updateSocialMediaDto.Twitter
            });
            return Ok("Sosyal medya güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            _socialMediaService.TDelete(socialMedia);
            return Ok("Sosyal medya silindi.");
        }
    }
}
