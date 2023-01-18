using Appointments.Domain;
using Appointments.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Infrastructure.Persistence
{
    public class SQLiteAppointmentRepository: IAppointmentRepository 
    {
        private AppointmentsContext _context;

        public SQLiteAppointmentRepository(AppointmentsContext context){
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> SearchAll()
        {
            return await _context.Appointments.ToListAsync();
        }
    }
}