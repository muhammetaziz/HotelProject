using AutoMapper;
using HotelDtoLayer.AboutDto;
using HotelDtoLayer.RoomAvailabilityDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class RoomAvailabilityMapping:Profile
    {
        public RoomAvailabilityMapping()
        {
            CreateMap<RoomAvailability, ToogleAvailabilityDto>().ReverseMap();
            CreateMap<RoomAvailability, UpdateQuotaDto>().ReverseMap();
        }
    }
}
