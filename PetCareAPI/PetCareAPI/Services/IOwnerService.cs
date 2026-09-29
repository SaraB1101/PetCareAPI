using PetCareAPI.DTOs.Owners;

namespace PetCareAPI.Services
{
    public interface IOwnerService
    {
        Task<List<OwnerResponseDto>> GetOwnersAsync();
        Task<OwnerResponseDto?> GetOwnerByIdAsync(int id);
        Task<OwnerResponseDto> CreateOwnerAsync(CreateOwnerDto createOwnerDto);
        Task<bool> UpdateOwnerAsync(int id, EditOwnerDto editOwnerDto);
        Task<bool> DeleteOwnerAsync(int id);
    }
}
