using Backend.Controllers.Appointments.Dtos;
using FluentValidation;

namespace Backend.Controllers.Appointments.Validations;

public class AppointmentPostRequestDTOValidator : AbstractValidator<AppointmentPostRequestDTO>
{
    public AppointmentPostRequestDTOValidator() { 
        RuleFor(x => x.AppointmentId).NotEmpty();
        RuleFor(x => x.StartDateTime).NotEmpty();
        RuleFor(x => x.EndDateTime).NotEmpty();
        RuleFor(x => x.Subject).NotEmpty();
        RuleFor(x => x.FromUserId).NotEmpty();
        RuleForEach(x => x.Receivers).NotNull();

    }

}

