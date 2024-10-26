using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("UserTransaction")]
    public class UserTransaction
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string ProcessId { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    }
}