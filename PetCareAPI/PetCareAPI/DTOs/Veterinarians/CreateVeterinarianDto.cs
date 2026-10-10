using PetCareAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.DTOs.Veterinarians
{
    public class CreateVeterinarianDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public Specialization Specialization { get; set; }
    }
}
