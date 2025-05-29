using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.RoomTypeDto
{
    public class UpdateRoomTypeDto
    {
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; } // Kaç kişilik
        public decimal PricePerNight { get; set; } // Gecelik fiyat
        public int AvailableRoomCount { get; set; } // Şu an müsait kaç tane var
        public string Description { get; set; }
        public IFormFile? RoomImage { get; set; }
    }
}
