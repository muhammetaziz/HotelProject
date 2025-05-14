using HotelWebUI.Dtos.ReservationDtos;
using HotelWebUI.Dtos.RoomAvailablilityDtos;
using HotelWebUI.Dtos.RoomTypeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelWebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = client.GetAsync("https://localhost:7219/api/Reservation").Result;
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Oda bilgileri alınamadı.");
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            return View();
        }

        public async Task<IActionResult> RoomList()
        {
            if (TempData["TotalPeople"] == null || TempData["CheckInDate"] == null || TempData["CheckOutDate"] == null)
                return RedirectToAction("Index", "Home");

            var totalPeople = (int)TempData["TotalPeople"];
            var checkInDate = Convert.ToDateTime(TempData["CheckInDate"]);
            var checkOutDate = Convert.ToDateTime(TempData["CheckOutDate"]);

            var client = _httpClientFactory.CreateClient();

            var requestDto = new ReservationSearchDto
            {
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                ChildCount =0,
                AdultCount = totalPeople
            };

            var response = await client.PostAsJsonAsync("https://localhost:7219/api/RoomAvailability/CheckAvailability", requestDto);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Seçtiğiniz tarihlerde uygun oda bulunamadı. Lütfen bizimle iletişime geçin.";
                return View("NoAvailableRooms");
            }

            var availableRooms = await response.Content.ReadFromJsonAsync<List<AvailableRoomDto>>();


            var mappedRooms = availableRooms.Select(x => new ResultRoomTypeDto
            {
                RoomTypeId = x.RoomTypeId,
                Capacity = x.Capacity,
                PricePerNight = x.PricePerNight,
                AvailableRoomCount = x.AvailableRoomCount,
                Description = x.RoomName
            }).ToList();

            if (mappedRooms == null || !mappedRooms.Any())
            {
                ViewBag.Message = "Seçtiğiniz tarihlerde uygun oda bulunamadı. Lütfen bizimle iletişime geçin.";
                return View("NoAvailableRooms");
            }

            // TempData'yı tekrar yaz çünkü TempData bir sonraki request'te silinir
            TempData["CheckInDate"] = checkInDate;
            TempData["CheckOutDate"] = checkOutDate;
            TempData["TotalPeople"] = totalPeople;

            return View(mappedRooms);
        }
    
        public IActionResult NoAvailableRooms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterGuestInfo(int RoomTypeId, int Quantity)
        {
            if (TempData["CheckInDate"] == null)
                return RedirectToAction("Index", "UserHome");

            var viewModel = new ReservationInfoDto
            {
                RoomTypeId = RoomTypeId,
                Quantity = Quantity,
                CheckInDate = (DateTime)TempData["CheckInDate"],
                CheckOutDate = (DateTime)TempData["CheckOutDate"],
                TotalPeople = (int)TempData["TotalPeople"]
            };

            TempData.Keep(); // TempData'yı sonraki adıma da taşıyabilmek için

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmReservation(ReservationInfoDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7219/api/RoomType/{model.RoomTypeId}");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Oda bilgileri alınamadı.");
                return View(model);
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var roomType = JsonConvert.DeserializeObject<ResultRoomTypeDto>(jsonData);

            var totalNights = (model.CheckOutDate - model.CheckInDate).Days;
            var totalPrice = roomType.PricePerNight * model.Quantity * totalNights;

            // ViewModel + Ödeme modelini hazırla
            var summaryModel = new ReservationSummaryDto
            {
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                RoomTypeId = model.RoomTypeId,
                RoomTypeName = roomType.Description,
                Quantity = model.Quantity,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                TotalPeople = model.TotalPeople,
                PricePerNight = roomType.PricePerNight,
                TotalPrice = totalPrice
            };

            TempData["ReservationData"] = JsonConvert.SerializeObject(summaryModel); // ödeme için sakla

            return View("ReservationSummary", summaryModel);
        }
        public IActionResult ReservationSummary()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompleteReservation(string ReservationDataJson)
        {
            if (string.IsNullOrEmpty(ReservationDataJson))
                return RedirectToAction("Index", "UserHome");

            var summary = JsonConvert.DeserializeObject<ReservationSummaryDto>(ReservationDataJson);

            // Sadece gerekli alanları doldur
            var createDto = new CreateReservationDto
            {
                FullName = summary.FullName,
                Email = summary.Email,
                Phone = summary.Phone,
                CheckInDate = summary.CheckInDate,
                CheckOutDate = summary.CheckOutDate,
                TotalPeople = summary.TotalPeople,
                resultReservationDetailDtos = new List<ResultReservationDetailDto>
        {
            new ResultReservationDetailDto
            {
                RoomTypeId = summary.RoomTypeId,
                Quantity = summary.Quantity
            }
        }
            };

            var client = _httpClientFactory.CreateClient();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(createDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7219/api/Reservation", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ThankYou");
            }

            // Hata varsa tekrar aynı view'a dön
            ViewBag.Error = "Rezervasyon sırasında bir hata oluştu.";
            return View("ReservationSummary", summary);
        }
        public IActionResult ThankYou()
        {
            return View();
        }

    }
}
