namespace PetCareAPI.DTOs.Appointments
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int VeterinarianId { get; set; }
        public string VeterinarianName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
