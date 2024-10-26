using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("UserFeedback")]
    public class UserFeedback
    {
        public int Id { get; set; }
        [Range(0,5, ErrorMessage = "Rating should be positive integer out of 5 stars")]
        public int Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Comment should be less than 500 characters")]
        public string? Comment { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}