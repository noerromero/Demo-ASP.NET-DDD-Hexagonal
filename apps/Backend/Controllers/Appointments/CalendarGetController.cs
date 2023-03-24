using Appointments.Calendars.Application;
using Appointments.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Appointments;


[ApiController]
[Route("api/calendars")]
public class CalendarGetController : ControllerBase
{
    private CalendarSearcher _calendarSearcher;
    private IMapper _mapper;

    public CalendarGetController(ICalendarRepository calendarRepository, IMapper mapper){
        _calendarSearcher = new CalendarSearcher(calendarRepository ?? throw new ArgumentNullException(nameof(calendarRepository)));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /* This method is not recommended because it's a get with body parameters
    [HttpGet]
    public async Task<IActionResult> GetByUserId([FromBody] CalendarGetRequestDTO calendarGetRequestDTO){
        var calendars = await _calendarSearcher.SearchByUserId(calendarGetRequestDTO.UserId);
        return Ok(_mapper.Map<IEnumerable<CalendarGetResponseDTO>>(calendars));
    }*/

    [HttpGet]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var calendars = await _calendarSearcher.SearchByUserId(userId);
        return Ok(_mapper.Map<IEnumerable<CalendarGetResponseDTO>>(calendars));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id){
        var calendar = await _calendarSearcher.SearchById(id);
        if (calendar == null)
            return NotFound();
        return Ok(_mapper.Map<CalendarGetResponseDTO>(calendar));
    }

}