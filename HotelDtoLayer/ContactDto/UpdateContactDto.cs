using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.ContactDto
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactAdress { get; set; }
        public string ContactDescription { get; set; }
        public string ContactMap { get; set; }
    }
}
