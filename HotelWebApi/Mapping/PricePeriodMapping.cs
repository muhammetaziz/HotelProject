using AutoMapper;
using HotelDtoLayer.PricePeriodDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class PricePeriodMapping : Profile
    {
        public PricePeriodMapping()
        {
            CreateMap<RoomTypePricePeriod, ResultRoomTypePricePeriodDto>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Description))
                .ForMember(dest => dest.SpecialPricePerNight, opt => opt.MapFrom(src => src.SpecialPricePerNight));
            CreateMap<RoomTypePricePeriod, CreateRoomTypePricePeriodDto>().ReverseMap();
            CreateMap<RoomTypePricePeriod, UpdateRoomTypePricePeriodDto>().ReverseMap();
        }
    }
}
