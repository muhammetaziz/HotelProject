using HotelWebUI.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebUI.Controllers
{
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7219/api/Reservation"); // API adresini uygun şekilde değiştir
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Rezervasyonlar alınamadı.";
                return View(new List<AdmınReservationListDto>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var reservations = JsonConvert.DeserializeObject<List<AdmınReservationListDto>>(jsonData);
            return View(reservations);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7219/api/Reservation/{id}"); // API adresini uygun şekilde değiştir
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Rezervasyon silinemedi.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7219/api/Reservation/details/{id}"); 
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Rezervasyon detayları alınamadı.";
                return RedirectToAction("Index");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var reservation = JsonConvert.DeserializeObject<ResultReservationWithDetailDto>(jsonData); 
            return View(reservation);
        }
    }
}
