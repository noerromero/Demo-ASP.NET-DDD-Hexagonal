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
    public Task<bool> CalendarExists(Guid appointmentID)
    {
        throw new NotImplementedException();
    }

    public async Task Create(Appointment appointment)
    {
        throw new NotImplementedException();
    }

   public async Task<IEnumerable<Calendar>> SearchByUserId(Guid userId)
    {
        return await _context.Calendars.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Calendar?> SearchById(Guid id){
        return await _context.Calendars.FirstOrDefaultAsync(x => x.Id == id);
    }
}