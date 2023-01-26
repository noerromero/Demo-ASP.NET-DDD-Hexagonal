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

        public async Task<Appointment> SearchByID(Guid appointmentID){
            //return await _context.Appointments.FindAsync(appointmentID.ToString());
            return await _context.Appointments
                            .FirstOrDefaultAsync(x => x.AppointmentID.ToString() == appointmentID.ToString());
        }

        public async Task Update(Appointment appointment){
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}