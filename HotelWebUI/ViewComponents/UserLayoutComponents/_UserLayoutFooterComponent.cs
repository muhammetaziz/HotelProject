﻿using HotelWebUI.Dtos.CommanDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelWebUI.ViewComponents.UserLayoutComponents
{

    public class _UserLayoutFooterComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserLayoutFooterComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
