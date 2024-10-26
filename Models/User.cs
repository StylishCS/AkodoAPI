using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(40, ErrorMessage = "Name should be less than 40 characters")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and be at least 8 characters long.")]
        public string Password { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string? MobilePhone { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string? WhatsappPhone { get; set; }
        [ForeignKey("University")]
        public int? UniversityId { get; set; }
        public University? University { get; set; }
        public UserFeedback? UserFeedback { get; set; }
        public string? OTP { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsPremium { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public bool IsSuspended { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public IEnumerable<Ad> Ads{ get; set; } = new List<Ad>();
        public IEnumerable<AdUserView> RecentlyViews{ get; set; } = new List<AdUserView>();
        public IEnumerable<AdUserWishlist> Wishlist{ get; set; } = new List<AdUserWishlist>();
        public IEnumerable<UserDocument> Documents { get; set; } = new List<UserDocument>();
        public IEnumerable<UserTransaction> Transactions { get; set; } = new List<UserTransaction>();
        //public IEnumerable<AdBedroomUserOccupancy> Occupancy { get; set; } = new List<AdBedroomUserOccupancy>();

    }
}
