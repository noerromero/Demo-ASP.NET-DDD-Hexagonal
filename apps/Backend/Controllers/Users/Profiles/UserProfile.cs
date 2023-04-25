
using AutoMapper;
using Backend.Controllers.Appointments.Dtos;
using Backend.Controllers.Users.Models;
using SharedOffice.Users.Domain;

namespace Backend.Controllers.Users.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{

        CreateMap<Helper, UserGetResponseDTO>()
                                .ForMember(d => d.CompleteName, opt => opt.MapFrom(s => s.CompleteName()));
                                
    }
}


