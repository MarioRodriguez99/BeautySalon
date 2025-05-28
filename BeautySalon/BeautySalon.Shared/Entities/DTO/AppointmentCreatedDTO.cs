using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Shared.Entities.DTO
{
    public class AppointmentCreatedDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ServiceId { get; set; }
    }
}