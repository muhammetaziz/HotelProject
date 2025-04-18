using AutoMapper;
using HotelDtoLayer.HotelServDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class HotelServMapping:Profile
    {
        public HotelServMapping()
        {
            CreateMap<HotelServ, ResultHotelServDto>().ReverseMap();
            CreateMap<HotelServ, CreateHotelServDto>().ReverseMap();
            CreateMap<HotelServ, GetHotelServDto>().ReverseMap();
            CreateMap<HotelServ, UpdateHotelServDto>().ReverseMap();
        }
    }
}
