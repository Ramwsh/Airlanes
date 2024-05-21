using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airlanes.Model.Entities
{
    [Table("Самолёт")]
    public class Plane
    {
        [Key]
        public int BoardNumber { get; set; }
        public string? Model { get; set; }
        public DateTime ServiceLife { get; set; }
        public bool ReadyOrNot {  get; set; }
    }
}
