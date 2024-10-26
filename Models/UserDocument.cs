using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkodoAPI.Models
{
    [Table("UserDocument")]
    public class UserDocument
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [RegularExpression("^Identity|Passport|Tax Register|Commercial Register", ErrorMessage = "Document Type Should Be One of Those Options: Identity, Passport, Tax Register, Commercial Register")]
        public string DocumentType { get; set; }
        [DataType(DataType.Url)]
        public string DocumentUrl { get; set; }
    }
}