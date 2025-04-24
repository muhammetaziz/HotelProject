using System.ComponentModel.DataAnnotations;

namespace HotelWebUI.Dtos.IdentityDtos
{
    public class LoginDto
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "Kullanıcı Adı 50 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "Kullanıcı Adı 3 karakterden az olamaz.")]
            
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        public string Password { get; set; }

    }
}
