using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Data;
using PetCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using PetCareAPI.DTOs.Owners;
using PetCareAPI.DTOs.Pets;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OwnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _context.Owners
                .Include(o => o.Pets)
                .ToListAsync();

            var ownerDtos = owners.Select(owner => new OwnerResponseDto
            {
                Id = owner.Id,
                Name = owner.Name,
                PhoneNumber = owner.PhoneNumber,
                Email = owner.Email,
                Address = owner.Address,
                HasInsurance = owner.HasInsurance,
                IsActive = owner.IsActive,
                Pets = owner.Pets.Select(pet => new PetSummaryDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Type = pet.Type
                }).ToList()
            }).ToList();

            return Ok(ownerDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(CreateOwnerDto createOwnerDto)
        {
            var ownerDto = new Owner
            {
                Name = createOwnerDto.Name,
                Email = createOwnerDto.Email,
                PhoneNumber = createOwnerDto.PhoneNumber,
                Address = createOwnerDto.Address,
                HasInsurance = createOwnerDto.HasInsurance
            };

            _context.Owners.Add(ownerDto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOwner), new { id = ownerDto.Id }, ownerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, EditOwnerDto editOwnerDto)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            owner.Name = editOwnerDto.Name;
            owner.Email = editOwnerDto.Email;
            owner.PhoneNumber = editOwnerDto.PhoneNumber;
            owner.Address = editOwnerDto.Address;
            owner.HasInsurance = editOwnerDto.HasInsurance;
            owner.IsActive = editOwnerDto.IsActive;

            await _context.SaveChangesAsync();

            var ownerResponseDto = new OwnerResponseDto
            {
                Id = owner.Id,
                Name = owner.Name,
                PhoneNumber = owner.PhoneNumber,
                Email = owner.Email,
                Address = owner.Address,
                HasInsurance = owner.HasInsurance,
                IsActive = owner.IsActive,
                Pets = owner.Pets.Select(pet => new PetSummaryDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Type = pet.Type
                }).ToList()
            };

            return Ok(ownerResponseDto);
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
            var owner = await _context.Owners
                .Include(o => o.Pets)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(new OwnerResponseDto
            {
                Id = owner.Id,
                Name = owner.Name,
                PhoneNumber = owner.PhoneNumber,
                Email = owner.Email,
                Address = owner.Address,
                HasInsurance = owner.HasInsurance,
                IsActive = owner.IsActive,
                Pets = owner.Pets.Select(pet => new PetSummaryDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Type = pet.Type
                }).ToList()
            });
        }
    }
}
