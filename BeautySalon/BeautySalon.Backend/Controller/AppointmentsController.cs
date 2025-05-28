using BeautySalon.Backend.Data;
using BeautySalon.Shared.Entities;
using BeautySalon.Shared.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly BeatySalonContext _context;

        public AppointmentsController(BeatySalonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAllAppointments()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Service)
                .ToListAsync();

            var result = appointments.Select(appointment => new AppointmentDTO
            {
                Id = appointment.Id,
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                ServiceName = appointment.Service?.Name ?? "Sin servicio",
                ServicePrice = appointment.Service?.Price ?? 0
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentCreatedDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = await _context.Services.FindAsync(dto.ServiceId);
            if (service == null)
                return NotFound($"Servicio con ID {dto.ServiceId} no encontrado.");

            var appointment = new Appointment
            {
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ServiceId = dto.ServiceId
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Devolver un DTO limpio al cliente
            var result = new AppointmentDTO
            {
                Id = appointment.Id,
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                ServiceName = service.Name,
                ServicePrice = service.Price
            };

            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
                return NotFound();

            var dto = new AppointmentDTO
            {
                Id = appointment.Id,
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                ServiceName = appointment.Service?.Name ?? "Sin servicio",
                ServicePrice = appointment.Service?.Price ?? 0
            };

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}