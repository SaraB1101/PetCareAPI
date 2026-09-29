namespace PetCareAPI.DTOs.Owners
{
    public class EditOwnerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool HasInsurance { get; set; }
        public bool IsActive { get; set; }
    }
}
