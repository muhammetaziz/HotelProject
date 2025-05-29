using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.RoomTypeDto
{
    public class CreateRoomTypeDto
    {
        public int Capacity { get; set; } // Kaç kişilik
        public decimal PricePerNight { get; set; } // Gecelik fiyat
        public int AvailableRoomCount { get; set; } // Şu an müsait kaç tane var
        public string Description { get; set; }
        public IFormFile? RoomImage { get; set; }
    }
}
