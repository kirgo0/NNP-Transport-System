using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    internal class Card
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int cardState { get; set; }

        [Required]
        public DateTime suitableFrom { get; set; }

        [Required]
        public DateTime suitableTo { get; set;}
    }
}
