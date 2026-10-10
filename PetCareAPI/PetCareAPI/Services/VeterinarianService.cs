using PetCareAPI.Data;
using PetCareAPI.DTOs.Veterinarians;
using Microsoft.EntityFrameworkCore;
using PetCareAPI.Models;
using PetCareAPI.DTOs.Appointments;

namespace PetCareAPI.Services
{
    public class VeterinarianService : IVeterinarianService
    {
        private readonly ApplicationDbContext _context;

        public VeterinarianService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VeterinarianResponseDto> CreateVeterinarianAsync(CreateVeterinarianDto createVeterinarianDto)
        {
            var veterinarian = new Veterinarian
            {
                Name = createVeterinarianDto.Name,
                PhoneNumber = createVeterinarianDto.PhoneNumber,
                Email = createVeterinarianDto.Email,
                Address = createVeterinarianDto.Address,
                Specialization = createVeterinarianDto.Specialization,
                IsActive = true
            };

            _context.Veterinarians.Add(veterinarian);
            await _context.SaveChangesAsync();

            var veterinarianDto = new VeterinarianResponseDto
            {
                Id = veterinarian.Id,
                Name = veterinarian.Name,
                PhoneNumber = veterinarian.PhoneNumber,
                Email = veterinarian.Email,
                Address = veterinarian.Address,
                Specialization = veterinarian.Specialization,
                IsActive = true
            };

            return veterinarianDto;
        }

        public async Task<bool> DeleteVeterinarianAsync(int id)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian == null)
            {
                return false;
            }
            _context.Veterinarians.Remove(veterinarian);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<VeterinarianResponseDto?> GetVeterinarianByIdAsync(int id)
        {
            var veterinarian = await _context.Veterinarians
                .Include(o => o.Appointments)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (veterinarian == null)
            {
                return null;
            }
            var veterinarianDto = new VeterinarianResponseDto
            {
                Id = veterinarian.Id,
                Name = veterinarian.Name,
                PhoneNumber = veterinarian.PhoneNumber,
                Email = veterinarian.Email,
                Address = veterinarian.Address,
                Specialization = veterinarian.Specialization,
                IsActive = veterinarian.IsActive,
                Appointments = veterinarian.Appointments.Select(a => new AppointmentSummaryDto
                {
                    Id = a.Id,
                    AppointmentDate = a.AppointmentDate,
                    Reason = a.Reason
                }).ToList()
            };
            return veterinarianDto;
        }

        public async Task<List<VeterinarianResponseDto>> GetVeterinariansAsync()
        {
            var veterinarians = await _context.Veterinarians
                .Include(v => v.Appointments)
                .ToListAsync();

            var veterinarianDtos = veterinarians.Select(v => new VeterinarianResponseDto
            {
                Id = v.Id,
                Name = v.Name,
                PhoneNumber = v.PhoneNumber,
                Email = v.Email,
                Address = v.Address,
                Specialization = v.Specialization,
                IsActive = v.IsActive,
                Appointments = v.Appointments.Select(a => new AppointmentSummaryDto
                {
                    Id = a.Id,
                    AppointmentDate = a.AppointmentDate,
                    Reason = a.Reason
                }).ToList()
            }).ToList();
            return veterinarianDtos;
        }

        public async Task<bool> UpdateVeterinarianAsync(int id, EditVeterinarianDto editVeterinarianDto)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian == null)
            {
                return false;
            }
            veterinarian.Name = editVeterinarianDto.Name;
            veterinarian.PhoneNumber = editVeterinarianDto.PhoneNumber;
            veterinarian.Email = editVeterinarianDto.Email;
            veterinarian.Address = editVeterinarianDto.Address;
            veterinarian.Specialization = editVeterinarianDto.Specialization;
            veterinarian.IsActive = editVeterinarianDto.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
