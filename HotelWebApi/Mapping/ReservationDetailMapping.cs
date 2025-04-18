using AutoMapper;
using HotelDtoLayer.ReservationDetailDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class ReservationDetailMapping:Profile
    {
        public ReservationDetailMapping()
        {
            CreateMap<ReservationDetail, ResultReservationDetailDto>().ReverseMap();
            CreateMap<ReservationDetail, GetReservationDetailDto>().ReverseMap();
            CreateMap<ReservationDetail, CreateReservationDetailDto>().ReverseMap();
            CreateMap<ReservationDetail, UpdateReservationDetailDto>().ReverseMap();
        }
    }
}
