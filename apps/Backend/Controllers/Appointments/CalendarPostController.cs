using HelperServices.Calendars.Application;
using HelperServices.Calendars.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Appointments;

[ApiController]
[Route("api/calendars")]
public class CalendarPostController : ControllerBase {
    private CalendarCreator _calendarCreator;
    private IMapper _mapper;

    public CalendarPostController(ICalendarRepository repository, IMapper mapper){
        _calendarCreator = new CalendarCreator(repository ?? throw new ArgumentNullException(nameof(repository)));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CalendarPostRequestDTO calendarPostRequestDTO){
        var calendar = _mapper.Map<Calendar>(calendarPostRequestDTO);
        
        await _calendarCreator.Create(calendar.Id
                                        , calendar.UserId
                                        , calendar.Name);
        
        return StatusCode(StatusCodes.Status201Created);

    }

}