using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Driver : Employee
    {
        [Required]
        public bool isAvailable { get; set; }
    }
}
