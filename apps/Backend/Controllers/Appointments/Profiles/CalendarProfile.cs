using Appointments.Calendars.Domain;
using AutoMapper;
using Backend.Controllers.Appointments.Models;

namespace Backend.Controllers.Appointments.Profiles
{
    public class CalendarProfile : Profile
    {
        public CalendarProfile(){
            CreateMap<Calendar, CalendarGetResponseDTO>();
        }
        
    }
}