using AutoMapper;
using HotelDtoLayer.ReservationDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class ReservationMapping:Profile
    {
        public ReservationMapping()
        {
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
        }
    }
}
