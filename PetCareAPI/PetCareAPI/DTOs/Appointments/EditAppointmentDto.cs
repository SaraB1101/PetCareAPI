using PetCareAPI.Models;

namespace PetCareAPI.DTOs.Appointments
{
    public class EditAppointmentDto
    {
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
