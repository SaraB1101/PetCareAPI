using System.ComponentModel.DataAnnotations;

namespace PetCareAPI.DTOs.Appointments
{
    public class CreateAppointmentDto
    {
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Reason { get; set; }
        public string Notes { get; set; }
    }
}
