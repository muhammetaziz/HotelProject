using HotelWebUI.Dtos.RoomTypeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelWebUI.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public RoomTypeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7219/api/RoomType");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomTypeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRoomType(ResultRoomTypeDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            if (dto.RoomTypeId == 0)
            {
                // Yeni ekleme
                var response = await client.PostAsync("https://localhost:7219/api/RoomType", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["ToastMessage"] = "Oda tipi başarıyla eklendi.";
                }
            }
            else
            {
                // Güncelleme
                var response = await client.PutAsync("https://localhost:7219/api/RoomType", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["ToastMessage"] = "Oda tipi başarıyla güncellendi.";
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7219/api/RoomType/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["ToastMessage"] = "Oda tipi silindi.";
            }

            return RedirectToAction("Index");
        }
    }
}
