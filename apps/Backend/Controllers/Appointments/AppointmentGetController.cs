using Microsoft.AspNetCore.Mvc;
using Appointments.Calendars.Domain;
using Appointments.Calendars.Application;
using AutoMapper;
using Backend.Appointments.Models;

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
    private IMapper _mapper;

    public AppointmentGetController(ICalendarRepository repository, IMapper mapper){
        _appointmentSearcher = new AppointmentSearcher(repository);
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
        

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        //implementend with _repository
        //var appointments = await _repository.SearchAll();
        //return appointments;

        //implemented with _application
        var appointments = await _appointmentSearcher.SearchAll();
        
        //return Ok(appointments);
        //return DTO
        return Ok(_mapper.Map<IEnumerable<AppointmentGetResponseDTO>>(appointments));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(Guid id){
        var appointment = await _appointmentSearcher.SearchByID(id);
        return Ok(_mapper.Map<AppointmentGetResponseDTO>(appointment));
    }
}