using Microsoft.EntityFrameworkCore;
using PetCareAPI.Data;
using PetCareAPI.DTOs.Owners;
using PetCareAPI.DTOs.Pets;
using PetCareAPI.Models;


namespace PetCareAPI.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDbContext _context;
        public OwnerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OwnerResponseDto> CreateOwnerAsync(CreateOwnerDto createOwnerDto)
        {
            var owner = new Owner
            {
                Name = createOwnerDto.Name,
                Email = createOwnerDto.Email,
                PhoneNumber = createOwnerDto.PhoneNumber,
                Address = createOwnerDto.Address,
                HasInsurance = createOwnerDto.HasInsurance
            };

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            
            var ownerDto = new OwnerResponseDto
            {
                Id = owner.Id,
                Name = owner.Name,
                PhoneNumber = owner.PhoneNumber,
                Email = owner.Email,
                Address = owner.Address,
                HasInsurance = owner.HasInsurance,
                IsActive = owner.IsActive
            };

            return ownerDto;
        }

        public async Task<bool> DeleteOwnerAsync(int id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return false;
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<OwnerResponseDto?> GetOwnerByIdAsync(int id)
        {
            var owner = await _context.Owners
                .Include(o => o.Pets)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (owner == null)
            {
                return null;
            }

            var ownerDto = new OwnerResponseDto
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
            return ownerDto;
        }

        public async Task<List<OwnerResponseDto>> GetOwnersAsync()
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

            return ownerDtos;
        }

        public async Task<bool> UpdateOwnerAsync(int id, EditOwnerDto editOwnerDto)
        {
            var owner = await _context.Owners.FindAsync(id);

            if(owner == null)
            {
                return false;
            }

            owner.Name = editOwnerDto.Name;
            owner.Email = editOwnerDto.Email;
            owner.PhoneNumber = editOwnerDto.PhoneNumber;
            owner.Address = editOwnerDto.Address;
            owner.HasInsurance = editOwnerDto.HasInsurance;
            owner.IsActive = editOwnerDto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
