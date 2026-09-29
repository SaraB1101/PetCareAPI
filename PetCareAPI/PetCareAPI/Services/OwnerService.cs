using Microsoft.EntityFrameworkCore;
using PetCareAPI.Data;
using PetCareAPI.DTOs.Owners;
using PetCareAPI.DTOs.Pets;

namespace PetCareAPI.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDbContext _context;
        public OwnerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<OwnerResponseDto> CreateOwnerAsync(CreateOwnerDto createOwnerDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOwnerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OwnerResponseDto?> GetOwnerByIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdateOwnerAsync(int id, EditOwnerDto editOwnerDto)
        {
            throw new NotImplementedException();
        }
    }
}
