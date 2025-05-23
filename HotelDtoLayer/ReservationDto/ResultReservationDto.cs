﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.ReservationDto
{
    public class ResultReservationDto
    {
        public int ReservationId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPeople { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
