using Appointments.Calendars.Domain;

namespace Appointments.Calendars.Application
{
    public class CalendarSearcher
    {
        private ICalendarRepository _calendarRepository;

        public CalendarSearcher(ICalendarRepository calendarRepository){
            _calendarRepository = calendarRepository ?? throw new ArgumentNullException(nameof(calendarRepository));
        }

        public async Task<IEnumerable<Calendar>> SearchByUserId(Guid userId){
            return await _calendarRepository.SearchCalendarByUserId(userId);
        }

        public async Task<Calendar?> SearchById(Guid id){
            return await _calendarRepository.SearchCalendarById(id);
        }
        
    }
}