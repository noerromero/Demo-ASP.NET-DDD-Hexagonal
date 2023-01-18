using Appointments.Domain;

namespace Appointments.Application
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
        
    }
}