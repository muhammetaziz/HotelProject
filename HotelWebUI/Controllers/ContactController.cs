using HotelWebUI.Dtos.CommentDtos;
using HotelWebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory) { _httpClientFactory = httpClientFactory; }

        #region AdminSide
        public async Task<IActionResult> Index()
        {
            var result = await _httpClientFactory.CreateClient().GetAsync("https://localhost:7219/api/Contact");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData) ; 
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7219/api/Contact/1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(ResultContactDto resultContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7219/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion
        #region UserSideComment&Contact

        [HttpGet]
        public IActionResult CommentContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CommentContact(CreateCommentDto createCommentDto)
        { 
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7219/api/Comment", stringContent); 
            if (responseMessage.IsSuccessStatusCode)
            {

                TempData["CommentSuccess"] = true;
                //await Task.Delay(3000);
                //return RedirectToAction("Index","UserHome");
                return View();
            }  

            return View();
        }

        #endregion
    }
}
