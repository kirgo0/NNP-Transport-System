using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ScheduleDTO
    {
        [Required]
        public int id { get; set; }

        [Required]
        public DateTime departureTime { get; set; }

        [Required]
        public DateTime arrivalTime { get; set; }

        [Required]
        public int trip_Id { get; set; }
    }
}
