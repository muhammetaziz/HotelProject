using Microsoft.AspNetCore.Http;

namespace HotelDtoLayer.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; } 
        public string AboutDescription { get; set; }

        public IFormFile? ImageFile1 { get; set; }
        public IFormFile? ImageFile2 { get; set; }
        public IFormFile? ImageFile3 { get; set; }

        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
    }
}
