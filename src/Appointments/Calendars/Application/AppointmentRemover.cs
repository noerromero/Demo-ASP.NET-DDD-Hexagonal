using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application{
    public class AppointmentRemover{
        private ICalendarRepository _repository;

        public AppointmentRemover(ICalendarRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Delete(Guid appointmentID){
            var appointment = await _repository.SearchAppointmentByID(appointmentID);

            if (appointment == null)
                return false;

            await _repository.DeleteAppointment(appointment);
            return true;
        }
    }
}
