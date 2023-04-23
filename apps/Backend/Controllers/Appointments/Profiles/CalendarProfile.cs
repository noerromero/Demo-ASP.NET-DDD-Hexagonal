using FrontOffice.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Models;

namespace Backend.Controllers.Appointments.Profiles
{
    public class CalendarProfile : Profile
    {
        public CalendarProfile(){
            CreateMap<Calendar, CalendarGetResponseDTO>()
                        .ForMember(d => d.CalendarId, opt => opt.MapFrom(s => s.Id));
            CreateMap<CalendarPostRequestDTO, Calendar>()
                        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CalendarId));

        }
        
    }
}