using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Shared.Entities
{
    public class Cita
    {
        public int Id { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public DateTime FechaHoraInicio { get; set; }
        public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;

        public enum EstadoCita
        {
            Pendiente,
            Confirmada,
            EnProgreso,
            Cancelada,
            Completada,
        }
    }
}