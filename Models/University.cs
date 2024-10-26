using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("University")]
    public class University
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name should be less than 50 characters")]
        public string Name { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        [MaxLength(100, ErrorMessage = "Address should be less than 100 characters")]
        public string AddressDetails { get; set; }
    }
}