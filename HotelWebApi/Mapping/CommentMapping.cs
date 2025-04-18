using AutoMapper;
using HotelDtoLayer.CommentDto;
using HotelEntityLayer.Entities;

namespace HotelWebApi.Mapping
{
    public class CommentMapping:Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, GetCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        }
    }
}
