using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Data;
using PetCareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pet updatedPet)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            pet.Name = updatedPet.Name;
            pet.Type = updatedPet.Type;
            pet.Age = updatedPet.Age;
            pet.Weight = updatedPet.Weight;
            pet.Breed = updatedPet.Breed;
            pet.OwnerId = updatedPet.OwnerId;

            await _context.SaveChangesAsync();

            return Ok(pet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

    }
}
