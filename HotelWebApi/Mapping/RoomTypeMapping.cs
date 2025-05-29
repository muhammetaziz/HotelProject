using AutoMapper;
using HotelDtoLayer.RoomTypeDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class RoomTypeMapping:Profile
    {
        public RoomTypeMapping()
        {
            CreateMap<RoomType, ResultRoomTypeDto>()
            .ForMember(dest => dest.ExistingImageUrl, opt => opt.MapFrom(src =>
                $"https://localhost:7219/{src.ImageUrl}")) // burayı ekledik
            .ReverseMap();
            CreateMap<RoomType, CreateRoomTypeDto>().ReverseMap();
            CreateMap<RoomType, GetRoomTypeDto>().ReverseMap();
            CreateMap<RoomType, UpdateRoomTypeDto>().ReverseMap();
        }
    }
}
