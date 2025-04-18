using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.ReservationDetailDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDetailController : ControllerBase
    {
        private readonly IReservationDetailService _reservationDetailService;
        private readonly IMapper _mapper;

        public ReservationDetailController(IReservationDetailService reservationDetailService, IMapper mapper)
        {
            _reservationDetailService = reservationDetailService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListReservationDetail()
        {
            var values = _mapper.Map<List<ResultReservationDetailDto>>(_reservationDetailService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateReservationDetail(CreateReservationDetailDto createReservationDetailDto)
        {
            _reservationDetailService.TInsert(new ReservationDetail
            {
                Reservation = new Reservation
                {
                    ReservationId = createReservationDetailDto.ReservationId
                },

                Quantity = createReservationDetailDto.Quantity,
                ReservationId = createReservationDetailDto.ReservationId,
                SubTotal = createReservationDetailDto.SubTotal,
                RoomTypeId = createReservationDetailDto.RoomTypeId
            });
            return Ok("Rezervasyon Detayı başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReservationDetail(int id)
        {
            var values = _reservationDetailService.TGetById(id);
            _reservationDetailService.TDelete(values);
            return Ok("Rezervasyon Detayı silindi.");
        }
        [HttpPut]
        public IActionResult UpdateReservationDetail(UpdateReservationDetailDto updateReservationDetailDto)
        {
            _reservationDetailService.TUpdate(new ReservationDetail
            {
                Quantity = updateReservationDetailDto.Quantity,
                ReservationId = updateReservationDetailDto.ReservationId,
                SubTotal = updateReservationDetailDto.SubTotal,
                RoomTypeId = updateReservationDetailDto.RoomTypeId
            });
            return Ok("Rezervasyon Detayı güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetReservationDetail(int id)
        {
            var values = _reservationDetailService.TGetById(id);
            var result = _mapper.Map<ResultReservationDetailDto>(values);
            return Ok(result);
        }
    }
}
