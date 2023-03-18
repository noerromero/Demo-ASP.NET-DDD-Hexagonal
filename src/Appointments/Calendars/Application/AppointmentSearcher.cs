using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application
{
    public class AppointmentSearcher
    {
        private ICalendarRepository _repository;

        public AppointmentSearcher(ICalendarRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Appointment>> SearchAll()
        {
            return await _repository.SearchAllAppointments();
        }

        public async Task<Appointment?> SearchByID(Guid appointmentId, bool includeReceivers){
            return await _repository.SearchAppointmentByID(appointmentId, includeReceivers);
        }
        
    }
}