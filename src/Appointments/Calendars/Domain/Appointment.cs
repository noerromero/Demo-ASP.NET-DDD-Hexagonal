using System.ComponentModel.DataAnnotations;

namespace Appointments.Calendars.Domain
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentID {get; set;}
        public DateTime StartDateTime {get; set;} 
        public DateTime EndDateTime {get; set;} 
        public int DurationInMinutes {get; set;} 
        public string Message {get; set;} 
        public Guid FromUserId {get; set;} 

        //public ICollection<To> ToUsers {get; set;}

        //public Appointment(){
            
        //}

        public Appointment(Guid appointmentID, DateTime startDateTime, DateTime endDateTime,
                            int durationInMinutes, string message, Guid fromUserId){
                            //,ICollection<To> toUsers){
            AppointmentID = appointmentID;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            DurationInMinutes = durationInMinutes;
            Message = message;
            FromUserId = fromUserId;
            //ToUsers = toUsers;
        }
        
    }
}