using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Shared.Entities.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
    }
}