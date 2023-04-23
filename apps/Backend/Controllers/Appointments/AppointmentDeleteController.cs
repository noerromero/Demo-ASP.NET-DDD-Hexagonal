using FrontOffice.Calendars.Application;
using FrontOffice.Calendars.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/calendars/{calendarId}/appointments")]

public class AppointmentDeleteController : ControllerBase
{
    private AppointmentRemover _appointmentRemover;

    public AppointmentDeleteController(ICalendarRepository repository){
        _appointmentRemover = new AppointmentRemover(repository);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid calendarId, Guid id){
        var success = await _appointmentRemover.Delete(id, calendarId);
        if (!success)
            return NotFound();
        return StatusCode(StatusCodes.Status204NoContent);
    }

}