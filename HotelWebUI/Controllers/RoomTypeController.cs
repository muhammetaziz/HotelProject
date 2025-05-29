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
                var values = JsonConvert.DeserializeObject<List<RoomTypeViewModel>>(jsonData);
                return View(values);
            }
            return View();
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

        [HttpGet]
        public IActionResult CreateRoomType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoomType(RoomTypeViewModel model)
        {
            using var client = new HttpClient();
            var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.Capacity.ToString()), "Capacity");
            form.Add(new StringContent(model.PricePerNight.ToString()), "PricePerNight");
            form.Add(new StringContent(model.AvailableRoomCount.ToString()), "AvailableRoomCount");
            form.Add(new StringContent(model.Description ?? ""), "Description");

            if (model.RoomImage != null)
            {
                var stream = model.RoomImage.OpenReadStream();
                var fileContent = new StreamContent(stream);
                form.Add(fileContent, "RoomImage", model.RoomImage.FileName);
            }

            var response = await client.PostAsync("https://localhost:7219/api/RoomType", form); // API URL'ini kendi projenle değiştir

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateRoomType(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7219/api/RoomType/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<RoomTypeViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoomType(RoomTypeViewModel model)
        {
            using var client = new HttpClient();
            var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.RoomTypeId.ToString()), "RoomTypeId");
            form.Add(new StringContent(model.Capacity.ToString()), "Capacity");
            form.Add(new StringContent(model.PricePerNight.ToString()), "PricePerNight");
            form.Add(new StringContent(model.AvailableRoomCount.ToString()), "AvailableRoomCount");
            form.Add(new StringContent(model.Description ?? ""), "Description");

            if (model.RoomImage != null)
            {
                var stream = model.RoomImage.OpenReadStream();
                var fileContent = new StreamContent(stream);
                form.Add(fileContent, "RoomImage", model.RoomImage.FileName);
            }

            var response = await client.PutAsync("https://localhost:7219/api/RoomType", form);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(model);
        }

    }
}
