using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        [Required]
        public string Name { get; set; }        
        public PetType Type { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string Breed { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
