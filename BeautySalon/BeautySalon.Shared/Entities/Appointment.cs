using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Shared.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Service? Service { get; set; }
        public int ServiceId { get; set; }
    }
}