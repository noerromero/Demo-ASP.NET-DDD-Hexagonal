using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application
{
    public class AppointmentSearcher
    {
        private IAppointmentRepository _repository;

        public AppointmentSearcher(IAppointmentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Appointment>> SearchAll()
        {
            return await _repository.SearchAll();
        }

        public async Task<Appointment?> SearchByID(Guid appointmentID){
            return await _repository.SearchByID(appointmentID);
        }
        
    }
}