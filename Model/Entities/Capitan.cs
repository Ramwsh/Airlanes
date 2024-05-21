using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Airlanes.Model.Entities
{
    [Table("КапитанКорабля")]
    public class Capitan
    {
        [Key]
        public int PersonalNumber { get; set; }
        public string? FIOc { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public int Raid { get; set; }
    }
}
