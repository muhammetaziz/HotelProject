using HotelWebUI.Dtos.RoomTypeDtos;
using HotelWebUI.Dtos.SpecialPriceDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelWebUI.Controllers
{
    public class SpecialPriceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialPriceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()

        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7219/api/PricePeriod");
            if (!response.IsSuccessStatusCode) return View(new List<SpecialPriceDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SpecialPriceDto>>(json);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Oda tiplerini çekmek için
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7219/api/RoomType");
            var json = await response.Content.ReadAsStringAsync();
            var roomTypes = JsonConvert.DeserializeObject<List<RoomTypeViewModel>>(json);
            ViewBag.RoomTypes = new SelectList(roomTypes, "RoomTypeId", "Description");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpecialPriceDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7219/api/PricePeriod", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7219/api/PricePeriod/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return NotFound();
        }

    }
}
