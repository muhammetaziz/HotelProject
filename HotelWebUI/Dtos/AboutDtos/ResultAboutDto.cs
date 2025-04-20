using System.ComponentModel.DataAnnotations;

namespace HotelWebUI.Dtos.AboutDtos
{
    public class ResultAboutDto
    {
        [Required(ErrorMessage = "Hakkımda ID boş geçilemez.")]
        public int AboutId { get; set; }
        [Required(ErrorMessage = "Hakkımda kısmı boş geçilemez.")]
        [Display(Name = "Hakkımda Kısmı")]
        [MinLength(100, ErrorMessage = "Hakkımda kısmı en az 100 karakter olmalıdır.")]
        [MaxLength(1000, ErrorMessage = "Hakkımda kısmı en fazla 1000 karakter olabilir.")]
        public string AboutDescription { get; set; }

        [Display(Name = "Resim 1")]
        [Required(ErrorMessage = "Resim 1 boş geçilemez.")]

        public string Image1 { get; set; }

        [Display(Name = "Resim 2")]
        [Required(ErrorMessage = "Resim 2 boş geçilemez.")]
        public string Image2 { get; set; }
        [Display(Name = "Resim 3")]
        [Required(ErrorMessage = "Resim 3 boş geçilemez.")]
        public string Image3 { get; set; }
    }
}
