namespace PetCareAPI.DTOs.Appointments
{
    public class AppointmentSummaryDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
    }
}
