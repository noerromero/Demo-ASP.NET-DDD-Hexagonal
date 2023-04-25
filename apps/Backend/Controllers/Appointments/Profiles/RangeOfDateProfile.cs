using HelperServices.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Dtos;

namespace Backend.Appointments.Profiles;

public class RangeOfDateProfile : Profile {
    
    public RangeOfDateProfile(){
        CreateMap<RangeOfDate, AppointmentGetResponseDTO>();
        CreateMap<AppointmentPostRequestDTO, RangeOfDate>();
        CreateMap<AppointmentPutRequestDTO, RangeOfDate>();
        CreateMap<AppointmentPatchRequestDTO, RangeOfDate>();
    }
}