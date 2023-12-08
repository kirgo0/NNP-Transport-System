using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    internal class Passanger : Employee
    {
        [Required]
        public bool isInBus { get; set; }
    }
}
