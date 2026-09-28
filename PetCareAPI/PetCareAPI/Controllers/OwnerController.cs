using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Data;
using PetCareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _context.Owners.ToListAsync();
            return Ok(owners);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOwner), new { id = owner.Id }, owner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, Owner updatedOwner)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            owner.Name = updatedOwner.Name;
            owner.Email = updatedOwner.Email;
            owner.PhoneNumber = updatedOwner.PhoneNumber;
            owner.Address = updatedOwner.Address;
            owner.HasInsurance = updatedOwner.HasInsurance;
            owner.IsActive = updatedOwner.IsActive;

            await _context.SaveChangesAsync();

            return Ok(owner);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }
    }
}
