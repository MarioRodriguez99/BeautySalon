using BeautySalon.Backend.Data;
using BeautySalon.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BeautySalon.Backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly BeatySalonContext _context;

        public ServicesController(BeatySalonContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Services.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return Ok(service);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Service service)
        {
            var putServices = await _context.Services.FindAsync(service.Id);
            if (putServices == null)
            {
                return NotFound();
            }
            putServices.Name = service.Name;
            putServices.Description = service.Description;
            putServices.Price = service.Price;
            putServices.State = service.State;
            _context.Services.Update(putServices);
            await _context.SaveChangesAsync();
            return Ok(putServices);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}