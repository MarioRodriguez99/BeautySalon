using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeautySalon.Shared.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool State { get; set; }

        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; set; }

        [NotMapped]
        public int? AppointmentsCount => Appointments?.Count ?? 0;
    }
}