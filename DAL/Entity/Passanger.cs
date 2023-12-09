using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Passanger : Employee
    {
        [Required]
        public bool isInBus { get; set; }
    }
}
