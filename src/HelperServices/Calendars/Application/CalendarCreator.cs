
using HelperServices.Calendars.Domain;

namespace HelperServices.Calendars.Application;

public class CalendarCreator {

    private ICalendarRepository _repository;
    public CalendarCreator(ICalendarRepository repository){
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Create(Guid calendarId
                                , Guid userId
                                , string name){
            
            await _repository.CreateCalendar(new Calendar(calendarId
                                        , userId, name));
        }

}