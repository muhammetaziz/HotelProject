using System.ComponentModel.DataAnnotations;

namespace HotelWebUI.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]

        public string? CommentName { get; set; }
        [Required(ErrorMessage = "Yorum alanı zorunludur.")]
        [StringLength(400, ErrorMessage = "Yorum alanı en fazla 4000 karakter olabilir.")]
        public string? CommentMessage { get; set; }
        [Required(ErrorMessage = "E-Mail alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]

        public string? CommentEmail { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public bool CommentActivate { get; set; } = false;

        public int RatingRange { get; set; }
    }
}
