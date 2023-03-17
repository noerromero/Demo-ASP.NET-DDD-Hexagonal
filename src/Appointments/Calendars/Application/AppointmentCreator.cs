using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application{
    
    public class AppointmentCreator{
        
        private ICalendarRepository _repository;
        public AppointmentCreator(ICalendarRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        
        public async Task Create(Guid appointmentID
                                , Guid CalendarId
                                , DateTimeOffset startDateTime
                                , DateTimeOffset endDateTime
                                , string message
                                , Guid fromUserID){
            
            
            await _repository.CreateAppointment(new Appointment(
                  appointmentID
                , CalendarId
                , startDateTime
                , endDateTime
                , message
                , fromUserID
                ));
        }

    }
}

