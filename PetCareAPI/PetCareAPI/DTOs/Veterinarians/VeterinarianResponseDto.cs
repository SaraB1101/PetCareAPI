using PetCareAPI.DTOs.Appointments;
using PetCareAPI.Models;

namespace PetCareAPI.DTOs.Veterinarians
{
    public class VeterinarianResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Specialization Specialization { get; set; }
        public bool IsActive { get; set; }
        public List<AppointmentSummaryDto> Appointments { get; set; } = new List<AppointmentSummaryDto>();
    }
}
