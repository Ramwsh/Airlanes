using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airlanes.Model.Entities
{
    [Table("Маршрут")]
    public class Route
    {
        [Key]
        public int NumberOfRoute { get; set; }
        public string? DepartureAirport { get; set; }
        public string? DestinationAirport { get; set; }
        public double Price { get; set; }
        public int FlightDuration { get; set; }
    }
}
