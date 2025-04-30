using HotelWebUI.Dtos.HotelServDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebUI.ViewComponents.UserHomePageComponents
{
    public class UserHomePageServicesComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserHomePageServicesComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()  
        {
            var result = await _httpClientFactory.CreateClient().GetAsync("https://localhost:7219/api/HotelServ");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultHotelServDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
