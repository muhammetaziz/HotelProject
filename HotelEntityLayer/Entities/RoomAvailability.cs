using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityLayer.Entities
{
    public class RoomAvailability
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvailableForSale { get; set; }
        public int RemainingQuota { get; set; }
        public int SoldQuota { get; set; }

        public RoomType RoomType { get; set; }
    }
}
