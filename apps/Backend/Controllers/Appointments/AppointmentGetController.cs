using Microsoft.AspNetCore.Mvc;
using Appointments.Domain;
using Appointments.Application;

namespace Backend.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentGetController : ControllerBase
{
    /*
    //implemented just _repository
    private IAppointmentRepository _repository;

    public AppointmentsGetController(IAppointmentRepository repository){
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    */

    //implemented with _application and repository
    private AppointmentSearcher _appointmentSearcher;
    public AppointmentGetController(IAppointmentRepository repository){
        _appointmentSearcher = new AppointmentSearcher(repository);
    }
        

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        //implementend with _repository
        //var appointments = await _repository.SearchAll();
        //return appointments;

        //implemented with _application
        var appointments = await _appointmentSearcher.SearchAll();
        return Ok(appointments);
    }
}