using Appointments.Domain;
using AutoMapper;
using Backend.Appointments.Models;

namespace Backend.Appointments.Profiles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile(){
        CreateMap<Appointment, AppointmentGetResponseDTO>();
        CreateMap<AppointmentPostRequestDTO, Appointment>();
        CreateMap<AppointmentPutRequestDTO, Appointment>();
        CreateMap<AppointmentPatchRequestDTO, Appointment>();
    }

}