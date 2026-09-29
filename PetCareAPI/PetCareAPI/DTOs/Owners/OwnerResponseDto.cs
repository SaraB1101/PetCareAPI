using PetCareAPI.DTOs.Pets;

namespace PetCareAPI.DTOs.Owners
{
    public class OwnerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool HasInsurance { get; set; }
        public bool IsActive { get; set; }

        public List<PetSummaryDto> Pets { get; set; } = new List<PetSummaryDto>();
    }
}
