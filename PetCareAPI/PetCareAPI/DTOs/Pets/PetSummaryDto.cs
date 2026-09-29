using PetCareAPI.Models;

namespace PetCareAPI.DTOs.Pets
{
    public class PetSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
    }
}
