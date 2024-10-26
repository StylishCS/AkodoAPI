using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("AdImage")]
    public class AdImage
    {
        [Key]
        [DataType(DataType.ImageUrl)]
        public int ImageUrl { get; set; }
        [ForeignKey("Ad")]
        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}