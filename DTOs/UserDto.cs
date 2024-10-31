using AkodoAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AkodoAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string MobilePhone { get; set; }
        public string WhatsappPhone { get; set; }
        public int UniversityId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsPremium { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public bool IsSuspended { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
