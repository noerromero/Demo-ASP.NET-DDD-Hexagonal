using FrontOffice.Calendars.Domain;

namespace FrontOffice.Calendars.Application{
    public class AppointmentRemover{
        private ICalendarRepository _repository;

        public AppointmentRemover(ICalendarRepository repository){
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Delete(Guid appointmentId, Guid calendarId){
            if (! await _repository.CalendarExists(calendarId))
                return false;

            var appointment = await _repository.SearchAppointmentByID(appointmentId, false);

            if (appointment == null)
                return false;

            await _repository.DeleteAppointment(appointment);
            return true;
        }
    }
}
