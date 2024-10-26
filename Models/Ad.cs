using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("Ad")]
    public class Ad
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        [MaxLength(255, ErrorMessage = "Address Details should be less than 255 characters")]
        public string AddressDetails { get; set; }
        [RegularExpression("^(Apartment|Studio)$", ErrorMessage = "Apartment Type Should Be One of Those Options: Apartment, Studio")]
        public string ApartmentType { get; set; }
        public bool IsFurnished { get; set; }
        [RegularExpression("^(Youth|Girls|Family)$", ErrorMessage = "Occupier Category Should Be One of Those Options: Youth, Girls, Family")]
        public string OccupierCategory { get; set; }
        [Range(0, 20, ErrorMessage = "Level number is invalid")]
        public int Level { get; set; }
        [RegularExpression(@"^(\s*[a-zA-Z0-9]+\s*)(,\s*[a-zA-Z0-9]+\s*)*$", ErrorMessage = "Amenities Should Be Seperated By Commas")]
        public string Amenities { get; set; }
        [Range(1, 10, ErrorMessage = "Please Enter A Valid Number")]
        public int Bathrooms { get; set; }
        [RegularExpression(@"^(\s*[a-zA-Z0-9]+\s*)(,\s*[a-zA-Z0-9]+\s*)*$", ErrorMessage = "Rate Includes Should Be Seperated By Commas")]
        public string RateIncludes { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Positive Numbers Only Allowed")]
        public int AdministrativeFees { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Positive Numbers Only Allowed")]
        public int Insurance { get; set; }
        [MaxLength(500, ErrorMessage = "Additional Notes should be less than 255 characters")]
        public string? AdditionalNotes { get; set; }
        public bool isAccepted { get; set; } = false;
        public bool isDeleted { get; set; } = false;
        public IEnumerable<AdImage> Images { get; set; } = new List<AdImage>();
        public IEnumerable<AdReport> Reports { get; set; } = new List<AdReport>();
        public IEnumerable<AdBedroom> Bedrooms { get; set; } = new List<AdBedroom>();

        public IEnumerable<AdUserView> RecentlyViews { get; set; } = new List<AdUserView>();
        public IEnumerable<AdUserWishlist> Wishlist { get; set; } = new List<AdUserWishlist>();
    }
}