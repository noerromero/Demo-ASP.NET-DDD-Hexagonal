using Appointments.Application;
using Appointments.Domain;
using AutoMapper;
using Backend.Appointments.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;



namespace Backend.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentPatchController : ControllerBase
{
    private AppointmentUpdater _appointmentUpdater;
    private IMapper _mapper;

    public AppointmentPatchController(IAppointmentRepository repository, IMapper mapper)
    {
        _appointmentUpdater = new AppointmentUpdater(repository);
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id,
                 [FromBody] JsonPatchDocument<AppointmentPatchRequestDTO> patchDocument){
        //JsonPatchDocument needs to install Json.Patch
                

        AppointmentPatchRequestDTO appointmentForUpdateDTO = new AppointmentPatchRequestDTO();
        //ModelState needs to install newtownsoftJson
        patchDocument.ApplyTo(appointmentForUpdateDTO,ModelState); 
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState); 
        if(!TryValidateModel(appointmentForUpdateDTO))
            return BadRequest(ModelState); 
        
        var success = await _appointmentUpdater.PartialUpdate(id
                                        , appointmentForUpdateDTO.StartDateTime
                                        , appointmentForUpdateDTO.EndDateTime
                                        , appointmentForUpdateDTO.DurationInMinutes
                                        , appointmentForUpdateDTO.Message
                                        , appointmentForUpdateDTO.FromUserId != null 
                                                ?  Guid.Parse(appointmentForUpdateDTO.FromUserId)
                                                : null);

        if (!success)
            return NotFound();
        return NoContent();
        //it's like : return StatusCode(StatusCodes.Status204NoContent); 
    }

}