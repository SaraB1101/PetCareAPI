using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.DTOs.Owners
{
    public class CreateOwnerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool HasInsurance { get; set; }
    }
}
