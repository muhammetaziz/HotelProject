using Azure;
using HotelWebUI.Dtos.CommanDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelWebUI.ViewComponents.UserLayoutComponents
{
    public class _UserLayoutTopHeaderComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutTopHeaderComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult > InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7219/api/UserTotal");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ContactSocialMediDto>(jsonData);
                return View(values);
            }


            return View();
        }
    }
}
