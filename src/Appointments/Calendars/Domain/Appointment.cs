using System.ComponentModel.DataAnnotations;
using SharedCore.Domain.Entity;

namespace Appointments.Calendars.Domain
{
    public class Appointment : BaseEntity<Guid>
    {
        public Guid CalendarId {get; private set;}
        public RangeOfDate RangeOfDates {get; private set;} 
        public string Message {get; private set;} 
        public Guid FromUserId {get; private set;}

        private Appointment(){
            
        }
        public Appointment(Guid id, DateTimeOffset startDateTime, DateTimeOffset endDateTime,
                            string message, Guid fromUserId){
            Id = id;
            RangeOfDates = new RangeOfDate(startDateTime,endDateTime);
            Message = message;
            FromUserId = fromUserId;
        }
        
    }
}