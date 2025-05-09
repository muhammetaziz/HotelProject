using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.ContactDto;
using HotelDtoLayer.ReservationDetailDto;
using HotelDtoLayer.ReservationDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult CreateReservation([FromBody] CreateReservationDto dto)
        {
            if (dto.CheckOutDate <= dto.CheckInDate)
                return BadRequest("Çıkış tarihi, giriş tarihinden sonra olmalıdır.");

            int totalNights = (dto.CheckOutDate - dto.CheckInDate).Days;
            decimal totalPrice = 0;
            var reservationDetails = new List<ReservationDetail>();

            foreach (var detail in dto.resultReservationDetailDtos)
            {
                var room = _roomTypeService.TGetById(detail.RoomTypeId);
                if (room == null)
                    return BadRequest($"RoomType with ID {detail.RoomTypeId} not found.");

                if (room.AvailableRoomCount < detail.Quantity)
                    return BadRequest($"Yeterli oda yok. RoomTypeID: {detail.RoomTypeId}");

                decimal subTotal = room.PricePerNight * detail.Quantity * totalNights;
                totalPrice += subTotal;

                reservationDetails.Add(new ReservationDetail
                {
                    RoomTypeId = detail.RoomTypeId,
                    Quantity = detail.Quantity,
                    SubTotal = subTotal,
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

        [HttpGet("withdetails")]
        public IActionResult ListReservationsWithDetails()
        {
            var reservations = _reservationService.GetListReservationWithDetails();

            var result = reservations.Select(r => new
            {
                r.ReservationId,
                r.FullName,
                r.Email,
                r.Phone,
                r.CheckInDate,
                r.CheckOutDate,
                r.TotalPeople,
                r.TotalPrice,
                r.Status,
                r.CreatedDate,
                ReservationDetails = r.ReservationDetails.Select(d => new
                {
                    d.ReservationDetailId,
                    d.RoomTypeId,
                    RoomTypeName = d.RoomType.Description,
                    d.Quantity,
                    d.SubTotal
                }).ToList()
            }).ToList();

            return Ok(result);
        }
        [HttpGet("details/{id}")]
        public IActionResult ListReservationWithDetailsById(int id)
        {
            var reservation = _reservationService.GetListReservationWithDetails().FirstOrDefault(x=>x.ReservationId==id);
            if (reservation == null)
                return NotFound("Rezervasyon bulunamadı.");

            var dto = new ReservationWithDetailsDto
            {
                ReservationId = reservation.ReservationId,
                FullName = reservation.FullName,
                Email = reservation.Email,
                Phone = reservation.Phone,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                TotalPeople = reservation.TotalPeople,
                TotalPrice = reservation.TotalPrice,
                Status = reservation.Status,
                CreatedDate = reservation.CreatedDate,
                ReservationDetails = reservation.ReservationDetails.Select(rd => new ReservationDetailAdminDto
                {
                    RoomTypeId = rd.RoomTypeId,
                    RoomTypeName = rd.RoomType?.Description,
                    PricePerNight = rd.RoomType?.PricePerNight ?? 0,
                    Quantity = rd.Quantity,
                    SubTotal = rd.SubTotal
                }).ToList()
            };

            return Ok(dto);
        }
    }
}
