

using FrontOffice.Calendars.Domain;

namespace FrontOffice.Calendars.Infrastructure.Persistence
{
    public class MySQLCalendarRepository : ICalendarRepository
    {
        public MySQLCalendarRepository(Appointment context)
        {
            
        }

        public Task<bool> AppointmentExists(Guid appointmentID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CalendarExists(Guid calendarId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task CreateCalendar(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task PartialUpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment?> SearchAppointmentByID(Guid appointmentId, bool includeReceivers)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> SearchAppointmentsByCalendarId(Guid calendarId)
        {
            throw new NotImplementedException();
        }

        public Task<Calendar?> SearchCalendarById(Guid calendarId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Calendar>> SearchCalendarsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
