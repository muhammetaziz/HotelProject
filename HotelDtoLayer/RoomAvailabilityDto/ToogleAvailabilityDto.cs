﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.RoomAvailabilityDto
{
    public class ToogleAvailabilityDto
    {
        public int RoomTypeId { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvailable { get; set; }
    }
}
