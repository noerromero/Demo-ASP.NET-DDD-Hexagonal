using Microsoft.AspNetCore.Mvc;
using HelperServices.Calendars.Domain;
using HelperServices.Calendars.Application;
using Backend.Controllers.Appointments.Models;
using AutoMapper;

namespace Backend.Controllers;

[ApiController]
[Route("api/calendars/{calendarId}/appointments")]
public class AppointmentPostController : ControllerBase
{
    AppointmentCreator _appointmentCreator;
    private IMapper _mapper;

    public AppointmentPostController(ICalendarRepository repository, IMapper mapper){
        _appointmentCreator = new AppointmentCreator(repository);
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /* Implementing Post method with primitive data types
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] dynamic body){
        body = JsonConvert.DeserializeObject(Convert.ToString(body));
        //await _bus.Dispatch(new CreateCourseCommand(id, body["name"].ToString(), body["duration"].ToString()));
        await _appointmentCreator.Create(Guid.Parse(body["AppointmentID"].ToString())
                                        , DateTime.Parse(body["StartDateTime"].ToString())
                                        , DateTime.Parse(body["EndDateTime"].ToString())
                                        , Int32.Parse(body["Duration"].ToString())
                                        , body["Message"].ToString()
                                        , Guid.Parse(body["FromUserID"].ToString()));
        //return StatusCode(201);
        return StatusCode(StatusCodes.Status201Created);

    }
    */

    
    //Implementing Post method with DTO class
    [HttpPost]
    public async Task<IActionResult> Post(Guid calendarId, [FromBody] AppointmentPostRequestDTO appointmentPostRequestDTO){
        var appointment = _mapper.Map<Appointment>(appointmentPostRequestDTO);
        //await _bus.Dispatch(new CreateCourseCommand(id, body["name"].ToString(), body["duration"].ToString()));
        await _appointmentCreator.Create(appointment.Id
                                        , calendarId
                                        , appointment.RangeOfDates.StartDateTime
                                        , appointment.RangeOfDates.EndDateTime
                                        , appointment.Subject
                                        , appointment.Message
                                        , appointment.FromUserId
                                        , appointment.Receivers);
        //return StatusCode(201);
        return StatusCode(StatusCodes.Status201Created);

    }
    
}