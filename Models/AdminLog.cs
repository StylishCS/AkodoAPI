using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("AdminLog")]
    public class AdminLog
    {
        public int Id { get; set; }
        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }
        [MaxLength(100, ErrorMessage = "Max Length Required is 100 character")]
        public string LogType { get; set; }
        [MaxLength(500, ErrorMessage = "Max Length Required is 500 character")]
        public string Action { get; set; }
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    }
}