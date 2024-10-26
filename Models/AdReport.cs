using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("AdReport")]
    [PrimaryKey(nameof(SessionId), nameof(AdId))]
    public class AdReport
    {
        public int SessionId { get; set; }
        [ForeignKey("Ad")]
        public int AdId { get; set; }
        public Ad Ad { get; set; }
        [RegularExpression("^Fake Ad|Unavailable|Wrong Information|Scam|Other$", ErrorMessage = "Occupier Category Should Be One of Those Options: Fake Ad, Unavailable, Wrong Information, Scam, Other")]
        public string Subject { get; set; }
        [MaxLength(500, ErrorMessage = "Description should be less than 500 character")]
        public string? Description { get; set; }
    }
}