using System.ComponentModel.DataAnnotations;

namespace Appointments.Domain
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentID {get; set;}
        public DateTime StartDateTime {get; set;}
        public DateTime EndDateTime {get; set;}
        public double Duration {get; set;}
        public string Message {get; set;}

        public Appointment(){

        }

        public Appointment(Guid appointmentID, DateTime startDateTime, DateTime endDateTime, double duration, string message){
            AppointmentID = appointmentID;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Duration = duration;
            Message = message;
        }
        
    }
}