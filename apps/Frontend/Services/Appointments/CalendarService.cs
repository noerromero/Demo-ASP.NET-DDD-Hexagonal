using Frontend.Models.Appointments;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;



namespace Frontend.Services.Appointments;

public class CalendarService : ICalendarService{
    private HttpClient _httpClient;

    public CalendarService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentException(nameof(httpClient));
    }

    public async Task<IEnumerable<Calendar>> GetCalendarByUserId (Guid userId){
        return await _httpClient.GetFromJsonAsync<IEnumerable<Calendar>>($"api/calendars?userid={userId.ToString()}");
    }

    public async Task<IList<Appointment>> GetAppointmentsByCalendarId(Guid calendarId){
        var result=  await _httpClient.GetFromJsonAsync<IList<Appointment>>
                                ($"api/calendars/{calendarId}/appointments");
        return result;
    }

    public async Task CreateAppointment(Appointment appointment, Guid calendarId) {
        await _httpClient.PostAsJsonAsync<Appointment>(
                                $"api/calendars/{calendarId}/appointments"
                                , appointment
                                );
        
            


    }

    public async Task UpdateAppointment(Appointment appointment, Guid calendarId)
    {
        await _httpClient.PutAsJsonAsync<Appointment>(
                                $"api/calendars/{calendarId}/appointments"
                                , appointment);
    }
}