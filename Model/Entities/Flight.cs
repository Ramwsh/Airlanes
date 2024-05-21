using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Airlanes.Model.Entities
{
    [Table("Рейс")]
    public class Flight
    {
        [Key]
        public int NumberOfFlight { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public bool ReadyOrNot { get; set; }
        public int RouteNumber { get; set; }
        public int BoardNumber { get; set; }
    }
}
