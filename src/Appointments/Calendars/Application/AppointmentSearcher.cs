using FrontOffice.Calendars.Domain;

namespace FrontOffice.Calendars.Application
{
    public class AppointmentSearcher
    {
        private ICalendarRepository _repository;

        public AppointmentSearcher(ICalendarRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Appointment>> SearchByCalendarId(Guid calendarId)
        {
            return await _repository.SearchAppointmentsByCalendarId(calendarId);
        }

        public async Task<Appointment?> SearchByID(Guid calendarId, Guid appointmentId, bool includeReceivers){
            if(! await _repository.CalendarExists(calendarId))
                return null;
            return await _repository.SearchAppointmentByID(appointmentId, includeReceivers);
        }
        
    }
}