using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.Models
{
    public class Owner
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public bool HasInsurance { get; set; }
        public bool IsActive { get; set; }
    }
}
