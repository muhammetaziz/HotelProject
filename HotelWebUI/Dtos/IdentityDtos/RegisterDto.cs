using System.ComponentModel.DataAnnotations;

namespace HotelWebUI.Dtos.IdentityDtos
{
    public class RegisterDto
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez.")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]

        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez.")]
        public string UserName { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        public string Mail { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [MaxLength(ErrorMessage ="Şifre 6 karakter uzunluğunda olmalı.")]
        [MinLength(6, ErrorMessage = "Şifre 6 karakter uzunluğunda olmalı.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]

        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")] 
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

    }
}
