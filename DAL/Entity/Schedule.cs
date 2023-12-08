using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    internal class Schedule
    {
        [Key]
        public int id { get; set; }

        [Required]
        public DateTime departureTime { get; set; }

        [Required]
        public DateTime arrivalTime { get; set; }

        public int trip_Id { get; set; }

        [ForeignKey("trip_id")]
        public virtual Trip Trip { get; set; }
    }
}
