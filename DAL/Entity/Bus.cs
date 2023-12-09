using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Entity
{
    public class Bus
    {
        [Key]
        public int id { get; set; }

        [Required]
        public bool isAvailable { get; set; }

        public int trip_Id { get; set; }

        [ForeignKey("trip_Id")]
        public virtual Trip Trip{ get; set; }
    }
}
