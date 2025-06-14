using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityLayer.Entities
{
    public class GlobalSettings
    {
        public int Id { get; set; }
        public bool IsSaleOpen { get; set; } // true: Satış açık, false: Satış kapalı
    }
}
