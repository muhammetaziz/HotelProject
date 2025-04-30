using HotelWebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebUI.ViewComponents.UserContactPageComponents
{
    public class UserContactPageComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserContactPageComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {

            var result = await _httpClientFactory.CreateClient().GetAsync("https://localhost:7219/api/Contact");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData).FirstOrDefault();
                return View(values);
            }
            return View();
        }
    }
}
