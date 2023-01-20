using Microsoft.AspNetCore.Mvc;
using Appointments.Domain;
using Appointments.Application;
using Newtonsoft.Json;

namespace Backend.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentPostController : ControllerBase
{
    AppointmentCreator _appointmentCreator;
    public AppointmentPostController(IAppointmentRepository repository){
        _appointmentCreator = new AppointmentCreator(repository);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] dynamic body){
        body = JsonConvert.DeserializeObject(Convert.ToString(body));
        //await _bus.Dispatch(new CreateCourseCommand(id, body["name"].ToString(), body["duration"].ToString()));
        await _appointmentCreator.Create(Guid.Parse(body["AppointmentID"].ToString())
                                        , DateTime.Parse(body["StartDateTime"].ToString())
                                        , DateTime.Parse(body["EndDateTime"].ToString())
                                        , Int32.Parse(body["Duration"].ToString())
                                        , body["Message"].ToString());
        return StatusCode(201);

    }

}