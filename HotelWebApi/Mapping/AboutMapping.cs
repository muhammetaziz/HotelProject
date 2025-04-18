using AutoMapper;
using HotelDtoLayer.AboutDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class AboutMapping : Profile
    {

        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}
