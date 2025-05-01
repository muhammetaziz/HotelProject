using HotelWebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebUI.ViewComponents.UserHomePageComponents
{
    public class UserHomePageAbout :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserHomePageAbout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result=await client.GetAsync("https://localhost:7219/api/About");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData).FirstOrDefault();
                return View(values);
            } 
            return View();
        }
    }
}
