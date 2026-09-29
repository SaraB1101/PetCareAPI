using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Data;
using PetCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using PetCareAPI.DTOs.Pets;

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
            var pets = await _context.Pets
                .Include(p => p.Owner)
                .ToListAsync();

            var petDtos = pets.Select(pet => new PetResponseDto
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Age = pet.Age,
                Weight = pet.Weight,
                Breed = pet.Breed,
                Gender = pet.Gender,
                OwnerId = pet.OwnerId,
                OwnerName = pet.Owner != null ? pet.Owner.Name : string.Empty
            }).ToList();

            return Ok(petDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(CreatePetDto createPetDto)
        {
            var ownerExists = await _context.Owners
                .AnyAsync(o => o.Id == createPetDto.OwnerId);

            if (!ownerExists)
            {
                return BadRequest("The specified owner does not exist.");
            }

            var pet = new Pet
            {
                OwnerId = createPetDto.OwnerId,
                Name = createPetDto.Name,
                Type = createPetDto.Type,
                Age = createPetDto.Age,
                Weight = createPetDto.Weight,
                Breed = createPetDto.Breed,
                Gender = createPetDto.Gender
            };

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, EditPetDto editPetDto)
        {
            var pet = await _context.Pets.FindAsync(id);
            
            if (pet == null)
            {
                return NotFound();
            }

            pet.OwnerId = editPetDto.OwnerId;
            pet.Name = editPetDto.Name;
            pet.Type = editPetDto.Type;
            pet.Age = editPetDto.Age;
            pet.Weight = editPetDto.Weight;
            pet.Breed = editPetDto.Breed;
            pet.Gender = editPetDto.Gender;
            pet.IsActive = editPetDto.IsActive;

            await _context.SaveChangesAsync();

            var petResponse = new PetResponseDto
            {
                Id = pet.Id,
                OwnerId = pet.OwnerId,
                Name = pet.Name,
                Type = pet.Type,
                Age = pet.Age,
                Weight = pet.Weight,
                Breed = pet.Breed,
                Gender = pet.Gender,
                IsActive = pet.IsActive
            };

            return Ok(petResponse);
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
            var pet = await _context.Pets
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            var petDto = new PetResponseDto
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Age = pet.Age,
                Weight = pet.Weight,
                Breed = pet.Breed,
                Gender = pet.Gender,
                OwnerId = pet.OwnerId,
                OwnerName = pet.Owner?.Name ?? string.Empty
            };
            return Ok(petDto);
        }

    }
}
