using AutoMapper;
using HotelDtoLayer.SocialMediaDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {

            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
        }
    }
}
