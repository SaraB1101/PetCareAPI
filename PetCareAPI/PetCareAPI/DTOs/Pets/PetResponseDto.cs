using PetCareAPI.Models;

namespace PetCareAPI.DTOs.Pets
{
    public class PetResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string Breed { get; set; }
        public Gender Gender { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public bool IsActive { get; set; }
    }
}
