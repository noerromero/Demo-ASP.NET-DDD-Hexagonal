using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application{
    public class AppointmentRemover{
        private ICalendarRepository _repository;

        public AppointmentRemover(ICalendarRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Delete(Guid appointmentId){
            var appointment = await _repository.SearchAppointmentByID(appointmentId, false);

            if (appointment == null)
                return false;

            await _repository.DeleteAppointment(appointment);
            return true;
        }
    }
}
