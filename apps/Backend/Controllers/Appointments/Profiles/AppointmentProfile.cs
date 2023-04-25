using HelperServices.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Dtos;

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
        CreateMap<Appointment, AppointmentGetResponseDTO>()
                                .ForMember(d => d.AppointmentId, opt => opt.MapFrom(s => s.Id))
                                .ForMember(d => d.StartDateTime, opt => opt.MapFrom(s => s.RangeOfDates.StartDateTime))
                                .ForMember(d => d.EndDateTime, opt => opt.MapFrom(s => s.RangeOfDates.EndDateTime))
                                .ForMember(d => d.DurationInMinutes, opt => opt.MapFrom(s => s.RangeOfDates.GetDurationInMinutes()))
                                .ForMember(d => d.Receivers, opt => opt.MapFrom(s => s.Receivers));
        
        CreateMap<Appointment, AppointmentWhitoutReceiverGetResponseDTO>()
                                .ForMember(d => d.AppointmentId, opt => opt.MapFrom(s => s.Id))
                                .ForMember(d => d.StartDateTime, opt => opt.MapFrom(s => s.RangeOfDates.StartDateTime))
                                .ForMember(d => d.EndDateTime, opt => opt.MapFrom(s => s.RangeOfDates.EndDateTime))
                                .ForMember(d => d.DurationInMinutes, opt => opt.MapFrom(s => s.RangeOfDates.GetDurationInMinutes()));
        
        CreateMap<AppointmentPostRequestDTO, Appointment>()
                                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AppointmentId))
                                .ForMember(d => d.RangeOfDates, opt => opt.MapFrom(s => s)) //this needs its independent profile converter
                                .ForMember(d => d.Receivers, opt => opt.MapFrom(s => s.Receivers)); //this needs its independent profile converter
        
        CreateMap<AppointmentPutRequestDTO, Appointment>()
                                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AppointmentId))
                                .ForMember(d => d.RangeOfDates, opt => opt.MapFrom(s => s))
                                .ForMember(d => d.Receivers, opt => opt.MapFrom(s => s.Receivers));

        CreateMap<AppointmentPatchRequestDTO, Appointment>()
                                .ForMember(d => d.RangeOfDates, opt => opt.MapFrom(s => s));
    }

}