using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public abstract class Employee
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public int card_Id { get; set; }

        [ForeignKey("card_Id")]
        public virtual Card Card { get; set; }

        public int bus_Id { get; set; }

        [ForeignKey("bus_id")]
        public virtual Bus Bus { get; set; }
    }
}
