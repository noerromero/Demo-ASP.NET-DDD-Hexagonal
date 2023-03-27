using Frontend.Models.Appointments;

namespace Frontend.Services.Appointments;
public interface ICalendarService{
    Task<IEnumerable<Calendar>> GetCalendarByUserId (Guid userId);
    Task<IList<Appointment>> GetAppointmentsByCalendarId(Guid calendarId);
    Task CreateAppointment(Appointment appointment, Guid calendarId);
    Task UpdateAppointment(Appointment appointment, Guid calendarId);

}