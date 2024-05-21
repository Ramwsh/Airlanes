using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airlanes.Model.Entities
{
    [Table("Пассажир")]
    public class Passanger
    {
        [Key]
        public int NumberOfPassport { get; set; }
        public string? FIOp {  get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
