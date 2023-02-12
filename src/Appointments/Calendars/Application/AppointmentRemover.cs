using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application{
    public class AppointmentRemover{
        private IAppointmentRepository _repository;

        public AppointmentRemover(IAppointmentRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Delete(Guid appointmentID){
            var appointment = await _repository.SearchByID(appointmentID);

            if (appointment == null)
                return false;

            await _repository.Delete(appointment);
            return true;
        }
    }
}
