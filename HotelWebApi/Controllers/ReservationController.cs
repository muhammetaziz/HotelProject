using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.ContactDto;
using HotelDtoLayer.ReservationDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IRoomTypeService _roomTypeService;

        public ReservationController(IReservationService reservationService, IMapper mapper, IRoomTypeService roomTypeService)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public IActionResult ListReservation()
        {
            var values = _mapper.Map<List<ResultReservationDto>>(_reservationService.TGetListAll());
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteReservation(int id)
        {
            var values = _reservationService.TGetById(id);
            _reservationService.TDelete(values);
            return Ok("Rezervasyon silindi.");
        }
        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {

            _reservationService.TUpdate(new Reservation
            {
                ReservationId = updateReservationDto.ReservationId,
                CheckInDate = updateReservationDto.CheckInDate,
                CheckOutDate = updateReservationDto.CheckOutDate,
                CreatedDate = updateReservationDto.CreatedDate,
                Email = updateReservationDto.Email,
                FullName = updateReservationDto.FullName,
                Phone = updateReservationDto.Phone,
                Status = updateReservationDto.Status,
                TotalPeople = updateReservationDto.TotalPeople,
                TotalPrice = updateReservationDto.TotalPrice

            });
            return Ok("Rezervasyon güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var values = _reservationService.TGetById(id);
            var result = _mapper.Map<GetReservationDto>(values);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto dto)
        {
            decimal totalPrice = 0;
            var reservationDetails = new List<ReservationDetail>();

            foreach (var detail in dto.resultReservationDetailDtos)
            {
                var room = _roomTypeService.TGetById(detail.RoomTypeId);
                if (room == null)
                    return BadRequest($"RoomType with ID {detail.RoomTypeId} not found.");

                if (room.AvailableRoomCount < detail.Quantity)
                    return BadRequest($"Yeterli oda yok. RoomTypeID: {detail.RoomTypeId}");

                decimal subTotal = room.PricePerNight * detail.Quantity;
                totalPrice += subTotal;

                reservationDetails.Add(new ReservationDetail
                {
                    RoomTypeId = detail.RoomTypeId,
                    Quantity = detail.Quantity,
                    SubTotal = subTotal
                });

                // Oda stoğundan düş
                room.AvailableRoomCount -= detail.Quantity;
                _roomTypeService.TUpdate(room);
            }

            var reservation = new Reservation
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                TotalPeople = dto.TotalPeople,
                TotalPrice = totalPrice,
                Status = "Pending",
                CreatedDate = DateTime.Now,
                ReservationDetails = reservationDetails
            };

            _reservationService.TInsert(reservation);

            return Ok("Rezervasyon başarıyla oluşturuldu.");
        }
    }
}
