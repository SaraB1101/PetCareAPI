using Microsoft.EntityFrameworkCore;
using PetCareAPI.Data;
using PetCareAPI.DTOs.Pets;
using PetCareAPI.Models;

namespace PetCareAPI.Services
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PetResponseDto> CreatePetAsync(CreatePetDto createPetDto)
        {
            var owner = await _context.Owners.FindAsync(createPetDto.OwnerId);

            if (owner == null)
            {
                return null;
            }            

            var pet = new Pet
            {
                OwnerId = createPetDto.OwnerId,
                Name = createPetDto.Name,
                Type = createPetDto.Type,
                Age = createPetDto.Age,
                Weight = createPetDto.Weight,
                Breed = createPetDto.Breed,
                Gender = createPetDto.Gender,
                IsActive = true
            };

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

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
                OwnerName = owner.Name,
                IsActive = pet.IsActive
            };

            return petDto;
        }

        public async Task<bool> DeletePetAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if(pet == null)
            {
                return false;
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PetResponseDto?> GetPetByIdAsync(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(pet == null)
            {
                return null;
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
                OwnerName = pet.Owner != null ? pet.Owner.Name : string.Empty,
                IsActive = pet.IsActive
            };

            return petDto;
        }

        public async Task<List<PetResponseDto>> GetPetsAsync()
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
                OwnerName = pet.Owner != null ? pet.Owner.Name : string.Empty,
                IsActive = pet.IsActive
            }).ToList();

            return petDtos;
        }

        public async Task<bool> UpdatePetAsync(int id, EditPetDto editPetDto)
        {
            var owner = await _context.Owners.FindAsync(editPetDto.OwnerId);

            if (owner == null)
            {
                return false;
            }

            var pet = await _context.Pets.FindAsync(id);

            if(pet == null)
            {
                return false;
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
            return true;
        }
    }
}
