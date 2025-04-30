using HotelWebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelWebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        } 


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7219/api/About");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { Field = x.Key, Error = x.Value.Errors.First().ErrorMessage });

                return BadRequest(errors);
            }
            var client = _httpClientFactory.CreateClient();
            var form = new MultipartFormDataContent();

            form.Add(new StringContent(createAboutDto.AboutDescription ?? ""), "AboutDescription");

            if (createAboutDto.ImageFile1 != null)
            {
                var streamContent = new StreamContent(createAboutDto.ImageFile1.OpenReadStream());
                form.Add(streamContent, "ImageFile1", createAboutDto.ImageFile1.FileName);
            }

            if (createAboutDto.ImageFile2 != null)
            {
                var streamContent = new StreamContent(createAboutDto.ImageFile2.OpenReadStream());
                form.Add(streamContent, "ImageFile2", createAboutDto.ImageFile2.FileName);
            }

            if (createAboutDto.ImageFile3 != null)
            {
                var streamContent = new StreamContent(createAboutDto.ImageFile3.OpenReadStream());
                form.Add(streamContent, "ImageFile3", createAboutDto.ImageFile3.FileName);
            }

            var response = await client.PostAsync("https://localhost:7219/api/About", form);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }
        #region Update Kısmı Hatalı
        //[HttpGet]
        //public async Task<IActionResult> UpdateAbout(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responceMessage = await client.GetAsync("https://localhost:7219/api/About/" + id);
        //    if (responceMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responceMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateAbout(ResultAboutDto resultAboutDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(resultAboutDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responceMessage = await client.PutAsync("https://localhost:7219/api/About", stringContent);
        //    if (responceMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //} 
        #endregion
    }
}
