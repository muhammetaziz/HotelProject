using AutoMapper;
using HotelDtoLayer.RoomTypeDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class RoomTypeMapping:Profile
    {
        public RoomTypeMapping()
        {
            CreateMap<RoomType, ResultRoomTypeDto>().ReverseMap();
            CreateMap<RoomType, CreateRoomTypeDto>().ReverseMap();
            CreateMap<RoomType, GetRoomTypeDto>().ReverseMap();
            CreateMap<RoomType, UpdateRoomTypeDto>().ReverseMap();
        }
    }
}
