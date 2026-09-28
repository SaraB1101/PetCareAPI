using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Data;
using PetCareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariansController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public VeterinariansController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVeterinarians()
        {
            var veterinarians = await _context.Veterinarians.ToListAsync();
            return Ok(veterinarians);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVeterinarian(Veterinarian veterinarian)
        {
            _context.Veterinarians.Add(veterinarian);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVeterinarian), new { id = veterinarian.Id }, veterinarian);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeterinarian(int id, Veterinarian updatedVeterinarian)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }
            veterinarian.Name = updatedVeterinarian.Name;
            veterinarian.PhoneNumber = updatedVeterinarian.PhoneNumber;
            veterinarian.Email = updatedVeterinarian.Email;
            veterinarian.Address = updatedVeterinarian.Address;
            veterinarian.Specialization = updatedVeterinarian.Specialization;
            veterinarian.IsActive = updatedVeterinarian.IsActive;
            await _context.SaveChangesAsync();
            return Ok(veterinarian);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinarian(int id)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }

            _context.Veterinarians.Remove(veterinarian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeterinarian(int id)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }
            return Ok(veterinarian);
        }
    }
}
