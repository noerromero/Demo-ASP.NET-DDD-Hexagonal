using Appointments.Calendars.Application;
using Appointments.Calendars.Domain;
using AutoMapper;
using Backend.Appointments.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentPutController : ControllerBase
{
    private AppointmentUpdater _appointmentUpdater;
    private IMapper _mapper;

    public AppointmentPutController(ICalendarRepository repository, IMapper mapper){
        _appointmentUpdater = new AppointmentUpdater(repository);
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    
    public async Task<IActionResult> Put([FromBody] AppointmentPutRequestDTO appointmentPutRequestDTO){
        var appointment = _mapper.Map<Appointment>(appointmentPutRequestDTO);
        var success = await _appointmentUpdater.Update(appointment.Id
                                        , appointment.CalendarId
                                        , appointment.RangeOfDates.StartDateTime
                                        , appointment.RangeOfDates.EndDateTime
                                        , appointment.Message
                                        , appointment.FromUserId);
        if (!success)
            return NotFound();
        return StatusCode(StatusCodes.Status204NoContent); 
    }
    
}