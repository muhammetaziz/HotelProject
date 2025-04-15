using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityLayer.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string ContactAdress { get; set; } = null!;
        public string ContactDescription { get; set; } = null!;
        public string ContactMap { get; set; } = null!;
    }
}
