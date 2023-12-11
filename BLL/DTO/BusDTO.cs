using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BusDTO
    {
        [Required]
        public int id { get; set; }

        [Required]
        public bool isAvailable { get; set; }

        [Required]
        public int maxSeatsAmount { get; set; }

        [Required]
        public int availableSeatsAmount { get; set; }

        [Required]
        public int trip_Id { get; set; }
    }
}
