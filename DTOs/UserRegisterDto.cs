using AkodoAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.DTOs
{
    public class UserRegisterDto
    {
        public int UniversityId { get; set; }
        [RegularExpression("^(Student|Owner)$", ErrorMessage = "User Type Should Be One Of Those Options: Student, Owner")]
        public string Type { get; set; }
        [RegularExpression("^(Broker|Office|Owner)$", ErrorMessage = "User Type Should Be One Of Those Options: Broker, Office, Owner")]
        public string? Subtype { get; set; }
        [MaxLength(40, ErrorMessage = "Name should be less than 40 characters")]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string MobilePhone { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and be at least 8 characters long.")]
        public string Password { get; set; }
    }
}
