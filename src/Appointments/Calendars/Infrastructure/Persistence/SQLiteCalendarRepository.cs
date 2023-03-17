using Appointments.Calendars.Domain;
using Appointments.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Calendars.Infrastructure.Persistence;

public class SQLiteCalendarRepository : ICalendarRepository
{
    private AppointmentsContext _context;

    public SQLiteCalendarRepository(AppointmentsContext context){
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<bool> CalendarExists(Guid calendarId)
    {
        return await _context.Calendars.AnyAsync(x => x.Id == calendarId);
    }

    public async Task CreateCalendar(Calendar calendar)
    {
        await _context.Calendars.AddAsync(calendar);
        await _context.SaveChangesAsync();
    }

   public async Task<IEnumerable<Calendar>> SearchCalendarByUserId(Guid userId)
    {
        return await _context.Calendars.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Calendar?> SearchCalendarById(Guid calendarId){
        return await _context.Calendars.FirstOrDefaultAsync(x => x.Id == calendarId);
    }

    public async Task CreateAppointment(Appointment appointment){
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Appointment>> SearchAllAppointments(){
        return await _context.Appointments.ToListAsync();
    }
    public async Task<Appointment?> SearchAppointmentByID(Guid appointmentID){
        var appointment = await _context.Appointments
                            .FirstOrDefaultAsync(x => x.Id == appointmentID);
            
        return appointment;
    }
    public async Task UpdateAppointment(Appointment appointment){
        _context.Entry(appointment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAppointment(Appointment appointment){
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> AppointmentExists(Guid appointmentID){
        return await _context.Appointments.AnyAsync(x => x.Id == appointmentID);
    }
}