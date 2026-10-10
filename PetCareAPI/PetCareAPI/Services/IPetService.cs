using PetCareAPI.DTOs.Pets;

namespace PetCareAPI.Services
{
    public interface IPetService
    {
        Task<List<PetResponseDto>> GetPetsAsync();
        Task<PetResponseDto?> GetPetByIdAsync(int id);
        Task<PetResponseDto> CreatePetAsync(CreatePetDto createPetDto);
        Task<bool> UpdatePetAsync(int id, EditPetDto editPetDto);
        Task<bool> DeletePetAsync(int id);
    }
}
