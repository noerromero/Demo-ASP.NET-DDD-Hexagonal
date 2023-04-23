using FrontOffice.Calendars.Application;
using FrontOffice.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/calendars/{calendarId}/appointments")]
public class AppointmentPutController : ControllerBase
{
    private AppointmentUpdater _appointmentUpdater;
    private IMapper _mapper;

    public AppointmentPutController(ICalendarRepository repository, IMapper mapper){
        _appointmentUpdater = new AppointmentUpdater(repository);
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    
    public async Task<IActionResult> Put(Guid calendarId, [FromBody] AppointmentPutRequestDTO appointmentPutRequestDTO){
        var appointment = _mapper.Map<Appointment>(appointmentPutRequestDTO);
        var success = await _appointmentUpdater.Update(appointment.Id
                                        , calendarId
                                        , appointment.RangeOfDates.StartDateTime
                                        , appointment.RangeOfDates.EndDateTime
                                        , appointment.Subject
                                        , appointment.Message
                                        , appointment.FromUserId
                                        , appointment.Receivers);
        if (!success)
            return NotFound();
        return StatusCode(StatusCodes.Status204NoContent); 
    }
    
}