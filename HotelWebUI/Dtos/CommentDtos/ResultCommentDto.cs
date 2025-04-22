namespace HotelWebUI.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string? CommentName { get; set; }
        public string? CommentMessage { get; set; }
        public string? CommentEmail { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentActivate { get; set; }
        public int RatingRange { get; set; }
    }
}
