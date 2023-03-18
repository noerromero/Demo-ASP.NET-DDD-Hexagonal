namespace Appointments.Calendars.Domain;

public interface ICalendarRepository 
{
    Task CreateCalendar(Calendar calendar);
    Task<IEnumerable<Calendar>> SearchCalendarByUserId(Guid userId);
    Task<Calendar?> SearchCalendarById(Guid calendarId);
    Task<bool> CalendarExists(Guid calendarId);

    Task CreateAppointment(Appointment appointment);
    Task<IEnumerable<Appointment>> SearchAllAppointments();
    Task<Appointment?> SearchAppointmentByID(Guid appointmentId, bool includeReceivers );
    Task UpdateAppointment(Appointment appointment);
    Task DeleteAppointment(Appointment appointment);
    Task<bool> AppointmentExists(Guid appointmentID);
}