using HelperServices.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Dtos;

namespace Backend.Appointments.Profiles;

public class ReceiverProfile : Profile {
    public ReceiverProfile(){
        CreateMap<Receiver, ReceiverDTO>()
                    .ForMember(d => d.ReceiverId, opt => opt.MapFrom(s => s.Id))
                    .ReverseMap();
    }
}