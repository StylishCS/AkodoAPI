using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("AdUserWishlist")]
    [PrimaryKey(nameof(AdId), nameof(UserId))]
    public class AdUserWishlist
    {
        [ForeignKey("Ad")]
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}