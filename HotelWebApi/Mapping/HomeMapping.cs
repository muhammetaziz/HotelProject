using AutoMapper;
using HotelDtoLayer.HomeDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class HomeMapping:Profile
    {
        public HomeMapping()
        {
            CreateMap<Home, ResultHomeDto>().ReverseMap();
            CreateMap<Home, CreateHomeDto>().ReverseMap();
            CreateMap<Home, GetHomeDto>().ReverseMap();
            CreateMap<Home, UpdateHomeDto>().ReverseMap();
        }
    }
}
