using Appointments.Calendars.Domain;
using AutoMapper;
using Backend.Appointments.Models;

namespace Backend.Appointments.Profiles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile(){

        //Map simple data type
        //CreateMap<Appointment, AppointmentGetResponseDTO>();
        //CreateMap<AppointmentPostRequestDTO, Appointment>();
        //CreateMap<AppointmentPutRequestDTO, Appointment>();
        //CreateMap<AppointmentPatchRequestDTO, Appointment>();


        //Map complex data type
        CreateMap<RangeOfDate, AppointmentGetResponseDTO>();
        CreateMap<Appointment, AppointmentGetResponseDTO>()
                                .ForMember(d => d.AppointmentId, opt => opt.MapFrom(s => s.Id))
                                .ForMember(d => d.StartDateTime, opt => opt.MapFrom(s => s.RangeOfDates.StartDateTime))
                                .ForMember(d => d.EndDateTime, opt => opt.MapFrom(s => s.RangeOfDates.EndDateTime));
        
        
        CreateMap<AppointmentPostRequestDTO, RangeOfDate>();
        CreateMap<AppointmentPostRequestDTO, Appointment>()
                                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AppointmentId))
                                .ForMember(d => d.RangeOfDates, opt => opt.MapFrom(s => s));
        
        
        CreateMap<AppointmentPutRequestDTO, Appointment>();
        CreateMap<AppointmentPatchRequestDTO, Appointment>();
    }

}