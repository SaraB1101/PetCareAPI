using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public int VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Reason { get; set; }

        public string Notes { get; set; }

        public AppointmentStatus Status { get; set; }
    }
}
