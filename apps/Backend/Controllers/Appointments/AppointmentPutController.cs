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

    public AppointmentPutController(IAppointmentRepository repository, IMapper mapper){
        _appointmentUpdater = new AppointmentUpdater(repository);
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /*
    public async Task<IActionResult> Put([FromBody] AppointmentPutRequestDTO appointmentPutRequestDTO){
        var appointment = _mapper.Map<Appointment>(appointmentPutRequestDTO);
        var success = await _appointmentUpdater.Update(appointment.AppointmentID
                                        , appointment.StartDateTime
                                        , appointment.EndDateTime
                                        , appointment.DurationInMinutes
                                        , appointment.Message
                                        , appointment.FromUserId);
        if (!success)
            return NotFound();
        return StatusCode(StatusCodes.Status204NoContent); 
    }
    */
}