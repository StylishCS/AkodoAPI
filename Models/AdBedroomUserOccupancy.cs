using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("AdBedroomUserOccupancy")]
    [PrimaryKey(nameof(UserId), nameof(AdBedroomId))]
    public class AdBedroomUserOccupancy
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("AdBedroom")]
        public int AdBedroomId { get; set; }
        public AdBedroom AdBedroom { get; set; }
        public DateTime OccupiedAt { get; set; } = DateTime.UtcNow;
        [Range(1, int.MaxValue, ErrorMessage = "Must Be At Least One Month")]
        public int OccupancyInterval { get; set; }
    }
}