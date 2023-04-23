using FrontOffice.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Models;

namespace Backend.Appointments.Profiles;

public class ReceiverProfile : Profile {
    public ReceiverProfile(){
        CreateMap<Receiver, ReceiverDTO>()
                    .ForMember(d => d.ReceiverId, opt => opt.MapFrom(s => s.Id))
                    .ReverseMap();
    }
}