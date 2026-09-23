using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.Models
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Specialization Specialization { get; set; }
        public bool IsActive { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
