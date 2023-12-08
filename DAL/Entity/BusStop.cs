using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    internal class BusStop
    {
        public BusStop()
        {
            Trips = new HashSet<Trip>();
        }

        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
