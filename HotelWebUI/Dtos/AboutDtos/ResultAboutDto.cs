using System.ComponentModel.DataAnnotations;

namespace HotelWebUI.Dtos.AboutDtos
{
    public class ResultAboutDto
    {
        
        public int AboutId { get; set; } 
        public string AboutDescription { get; set; } 
        public string Image1 { get; set; } 
        public string Image2 { get; set; } 
        public string Image3 { get; set; }
    }
}
