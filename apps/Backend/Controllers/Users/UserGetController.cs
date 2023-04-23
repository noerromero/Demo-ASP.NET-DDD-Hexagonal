
using HelperServices.Calendars.Application;
using AutoMapper;
using Backend.Controllers.Appointments.Models;
using Backend.Controllers.Users.Models;
using Microsoft.AspNetCore.Mvc;
using SharedOffice.Users.Application;
using SharedOffice.Users.Domain;

namespace Backend.Controllers.Users;


[ApiController]
[Route("api/users")]
public class UserGetController : ControllerBase
{
    private UserSearcher _userSearcher;
    private IMapper _mapper;

    public UserGetController(IUserRepository repository, IMapper mapper)
	{
        _userSearcher = new UserSearcher(repository);
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));

    }

    [HttpGet]
    public async Task<IActionResult> GetAllHelpers(Guid calendarId)
    {
        
        var helpers = await _userSearcher.SearchAllHelpers();
        return Ok(_mapper.Map<IEnumerable<UserGetResponseDTO>>(helpers));
    }
}


