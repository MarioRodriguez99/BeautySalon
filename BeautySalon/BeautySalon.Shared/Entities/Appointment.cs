using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Shared.Entities
{
    internal class Appointment
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public User User { get; set; }
    }
}