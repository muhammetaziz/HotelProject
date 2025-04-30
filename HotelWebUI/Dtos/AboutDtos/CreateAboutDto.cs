using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HotelWebUI.Dtos.AboutDtos
{
    public class CreateAboutDto
    {

        public string AboutDescription { get; set; }
        public IFormFile ImageFile1 { get; set; }
        public IFormFile ImageFile2 { get; set; }
        public IFormFile ImageFile3 { get; set; }


    }

}
