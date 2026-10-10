using PetCareAPI.DTOs.Veterinarians;

namespace PetCareAPI.Services
{
    public interface IVeterinarianService
    {
        Task<List<VeterinarianResponseDto>> GetVeterinariansAsync();
        Task<VeterinarianResponseDto?> GetVeterinarianByIdAsync(int id);
        Task<VeterinarianResponseDto> CreateVeterinarianAsync(CreateVeterinarianDto createVeterinarianDto);
        Task<bool> UpdateVeterinarianAsync(int id, EditVeterinarianDto editVeterinarianDto);
        Task<bool> DeleteVeterinarianAsync(int id);
    }
}
