using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityLayer.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string AboutDescription { get; set; } = null!;
        public string Image1 { get; set; }=null!;
        public string Image2 { get; set; }= null!;
        public string Image3 { get; set; }=null!;

    }
}
