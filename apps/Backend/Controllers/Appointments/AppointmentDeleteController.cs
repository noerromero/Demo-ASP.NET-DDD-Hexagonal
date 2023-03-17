using Appointments.Calendars.Application;
using Appointments.Calendars.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/appointments")]

public class AppointmentDeleteController : ControllerBase
{
    private AppointmentRemover _appointmentRemover;

    public AppointmentDeleteController(ICalendarRepository repository){
        _appointmentRemover = new AppointmentRemover(repository);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id){
        var success = await _appointmentRemover.Delete(id);
        if (!success)
            return NotFound();
        return StatusCode(StatusCodes.Status204NoContent);
    }

}