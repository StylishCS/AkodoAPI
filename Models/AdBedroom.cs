using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("AdBedroom")]
    public class AdBedroom
    {
        public int Id { get; set; }
        [ForeignKey("Ad")]
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        [RegularExpression("^(Single|Double|Triple|Quad)$", ErrorMessage = "Occupier Category Should Be One of Those Options: Single, Double, Triple, Quad")]
        public string Occupancy { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Positive Numbers Only Allowed")]
        public int Rate { get; set; }
    }
}