using HotelWebUI.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelWebUI.ViewComponents.UserHomePageComponents
{
    public class UserHomePageTestimonialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserHomePageTestimonialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7219/api/Comment");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
