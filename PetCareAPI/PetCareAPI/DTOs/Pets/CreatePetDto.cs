using PetCareAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.DTOs.Pets
{
    public class CreatePetDto
    {
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PetType Type { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        public decimal Weight { get; set; }
        [StringLength(100)]
        public string Breed { get; set; }
        public Gender Gender { get; set; }
    }
}
