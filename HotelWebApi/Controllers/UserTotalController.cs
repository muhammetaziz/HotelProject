using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.ContactDto;
using HotelDtoLayer.SocialMediaDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTotalController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public UserTotalController(IContactService contactService, ISocialMediaService socialMediaService, IMapper mapper)
        {
            _contactService = contactService;
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetContactAndSocial()
        {
            var contactValues = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            var socialValues = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(new { contactValues, socialValues });
        }
    }
}
