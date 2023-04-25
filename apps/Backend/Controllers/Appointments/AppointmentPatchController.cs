using HelperServices.Calendars.Application;
using HelperServices.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;



namespace Backend.Controllers;

[ApiController]
[Route("api/calendars/{calendarId}/appointments")]
public class AppointmentPatchController : ControllerBase
{
    private AppointmentUpdater _appointmentUpdater;
    private IMapper _mapper;

    public AppointmentPatchController(ICalendarRepository repository, IMapper mapper)
    {
        _appointmentUpdater = new AppointmentUpdater(repository);
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid calendarId, Guid id,
                 [FromBody] JsonPatchDocument<AppointmentPatchRequestDTO> patchDocument){
        //JsonPatchDocument needs to install Json.Patch
                

        AppointmentPatchRequestDTO appointmentForUpdateDTO = new AppointmentPatchRequestDTO();
        //ModelState needs to install newtownsoftJson
        patchDocument.ApplyTo(appointmentForUpdateDTO,ModelState); 
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState); 
        if(!TryValidateModel(appointmentForUpdateDTO))
            return BadRequest(ModelState); 
        
        var success = await _appointmentUpdater.PartialUpdate(id, calendarId
                                        , appointmentForUpdateDTO.StartDateTime
                                        , appointmentForUpdateDTO.EndDateTime
                                        , appointmentForUpdateDTO.Subject
                                        , appointmentForUpdateDTO.Message
                                        );

        if (!success)
            return NotFound();
        return NoContent();
        //it's like : return StatusCode(StatusCodes.Status204NoContent); 
    }
    
}