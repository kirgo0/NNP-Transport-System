using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    internal class Trip
    {
        public Trip()
        {
            BusStops = new HashSet<BusStop>(); 
        }

        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public virtual ICollection<BusStop> BusStops { get; set; }
    }
}
