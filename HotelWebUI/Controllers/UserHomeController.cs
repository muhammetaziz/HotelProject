using HotelWebUI.Dtos.AboutDtos;
using HotelWebUI.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebUI.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserHomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ReservationSearchDto reservationSearchDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData["CheckInDate"] = reservationSearchDto.CheckInDate;
            TempData["CheckOutDate"] = reservationSearchDto.CheckOutDate;
            TempData["TotalPeople"] = reservationSearchDto.AdultCount ;
            //TempData["TotalPeople"] = reservationSearchDto.AdultCount+reservationSearchDto.ChildCount;
            return RedirectToAction("RoomList", "Reservation");
        }

        public async Task<IActionResult> UserAbout()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7219/api/About");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData).FirstOrDefault();
                return View(values);
            }
            return NotFound();
        }

    }
}
