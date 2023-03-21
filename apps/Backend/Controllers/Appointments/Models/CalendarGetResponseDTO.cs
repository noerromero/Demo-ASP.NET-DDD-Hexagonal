namespace Backend.Controllers.Appointments.Models
{
    public class CalendarGetResponseDTO
    {
        public string CalendarId {get; set;} = string.Empty;
        public string UserId {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
    }
}