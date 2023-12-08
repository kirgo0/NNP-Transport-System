using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    internal class Driver : Employee
    {
        [Required]
        public bool isAvailable { get; set; }
    }
}
