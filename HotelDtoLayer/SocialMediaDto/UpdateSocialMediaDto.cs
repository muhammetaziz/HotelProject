using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDtoLayer.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string  Instagram { get; set; }
        public string  Facebook { get; set; }
        public string  Twitter { get; set; }
    }
}
