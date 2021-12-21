namespace usos.API.Application.Models.Lecturer
{
    public class LecturerUpdateRequest
    {
        public string CardId { get; set; }
        
        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}