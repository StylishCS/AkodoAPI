using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("Admin")]
    public class Admin
    {
        public int Id { get; set; }
        [ForeignKey("SuperAdmin")]
        public int? SuperId { get; set; }
        public Admin? SuperAdmin { get; set; }
        [MaxLength(50, ErrorMessage = "Max Length Required is 50 character")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and be at least 8 characters long.")]
        public string Password { get; set; }
        public string? OTP { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public IEnumerable<AdminLog> Logs { get; set; } = new List<AdminLog>();
    }
}
