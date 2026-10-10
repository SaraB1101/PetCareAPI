using PetCareAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.DTOs.Veterinarians
{
    public class EditVeterinarianDto
    {
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public Specialization Specialization { get; set; }
        public bool IsActive { get; set; }
    }
}
