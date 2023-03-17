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

        public async Task<Appointment?> SearchByID(Guid appointmentID){
            return await _repository.SearchAppointmentByID(appointmentID);
        }
        
    }
}