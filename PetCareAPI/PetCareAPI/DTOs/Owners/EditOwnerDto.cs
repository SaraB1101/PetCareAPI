using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.DTOs.Owners
{
    public class EditOwnerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool HasInsurance { get; set; }
        public bool IsActive { get; set; }
    }
}
