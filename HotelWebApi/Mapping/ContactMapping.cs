using AutoMapper;
using HotelDtoLayer.ContactDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        { 
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
