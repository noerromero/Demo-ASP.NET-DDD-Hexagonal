using System.ComponentModel.DataAnnotations;
using SharedCore.Domain.Entity;

namespace HelperServices.Calendars.Domain
{
    public class Appointment : BaseEntity<Guid>
    {
        public Guid CalendarId {get; private set;}
        public RangeOfDate RangeOfDates {get; private set;}
        public string Subject { get; private set; }
        public string Message {get; private set;} 
        public Guid FromUserId {get; private set;}
        public IEnumerable<Receiver> Receivers {get; private set;} = new List<Receiver>();

        private Appointment(){
            
        }
        public Appointment(Guid id, Guid calendarId
                            , DateTime startDateTime
                            , DateTime endDateTime
                            , string subject
                            , string message, Guid fromUserId
                            , IEnumerable<Receiver> receivers){
            Id = id;
            CalendarId = calendarId;
            RangeOfDates = new RangeOfDate(startDateTime,endDateTime);
            Subject = subject;
            Message = message;
            FromUserId = fromUserId;
            Receivers = receivers;
        }


        public void SetSubject(string newSubject) => Subject = newSubject;
        public void SetMessage(string newMessage) => Message = newMessage;
        public void SetFromUserId(Guid newFromUserId) => FromUserId = newFromUserId;
        public void SetCalendarId(Guid newCalendarid) => CalendarId = newCalendarid;
        public void SetReceivers(IEnumerable<Receiver> newReceivers) => Receivers = newReceivers;
        
    }
}