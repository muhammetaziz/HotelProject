using HotelEntityLayer.Entities;
using HotelWebUI.Dtos.RoomAvailablilityDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace HotelWebUI.Controllers
{
    public class RoomAvailabilityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomAvailabilityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(DateTime? start, DateTime? end)
        {
            var startDate = start ?? DateTime.Today;
            var endDate = end ?? DateTime.Today.AddDays(14);

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7219/api/RoomAvailability/GetAvailability?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");

            if (!response.IsSuccessStatusCode)
                return View(new RoomAvailabilityTableViewModel());

            var jsonData = await response.Content.ReadAsStringAsync();
            var flatList = JsonConvert.DeserializeObject<List<AvailabilityDto>>(jsonData);

            var grouped = flatList
                .GroupBy(x => new { x.RoomTypeId, x.RoomTypeName })
                .Select(g => new RoomAvailabilityRowViewModel
                {
                    RoomTypeId = g.Key.RoomTypeId,
                    RoomTypeName = g.Key.RoomTypeName,
                    AvailabilityPerDate = g.Select(item => new RoomAvailabilityCellViewModel
                    {
                        Date = item.Date,
                        RemainingQuota = item.RemainingQuota,
                        SoldQuota = 0, // Eğer satılan bilgisi de geliyorsa ekle
                        IsAvailableForSale = item.IsAvailableForSale
                    }).ToList()
                }).ToList();

            var dateList = flatList.Select(x => x.Date).Distinct().OrderBy(x => x).ToList();

            var model = new RoomAvailabilityTableViewModel
            {
                Dates = dateList,
                RoomTypes = grouped
            };
            return View(model);
        } 
    }
}
