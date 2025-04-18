using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.CommentDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        #region CommentApiCrud
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListComment()
        {
            var values = _mapper.Map<List<ResultCommentDto>>(_commentService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto createCommentDto)
        {
            _commentService.TInsert(new Comment()
            {
                CommentActivate = createCommentDto.CommentActivate,
                CommentDate = createCommentDto.CommentDate,
                CommentEmail = createCommentDto.CommentEmail,
                CommentMessage = createCommentDto.CommentMessage,
                CommentName = createCommentDto.CommentName,
                RatingRange = createCommentDto.RatingRange
            });
            return Ok("Yorum başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.TGetById(id);
            _commentService.TDelete(values);
            return Ok("Seçili yorum başarılı bir şekilde silindi.");

        }
        [HttpPut]
        public IActionResult UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var values = _commentService.TGetById(updateCommentDto.CommentId);
            if (values == null)
            {
                return NotFound("Yorum bulunamadı.");
            }
            values.CommentId = updateCommentDto.CommentId;
            values.CommentActivate = updateCommentDto.CommentActivate;
            values.CommentDate = updateCommentDto.CommentDate;
            values.CommentEmail = updateCommentDto.CommentEmail;
            values.CommentMessage = updateCommentDto.CommentMessage;
            values.CommentName = updateCommentDto.CommentName;
            values.RatingRange = updateCommentDto.RatingRange;
            _commentService.TUpdate(values);
            return Ok("Seçili yorum başarılı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _commentService.TGetById(id);
            if (values == null)
            {
                return NotFound("Yorum bulunamadı.");
            }
            return Ok(values);
        }
        #endregion
    }
}
