using Appointments.Calendars.Domain;
using Appointments.Shared.Infrastructure.Persistence.EntityFramework;
using Appointments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add manually
builder.Services.AddDbContext<AppointmentsContext>(x => {
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//add manually
builder.Services.AddScoped<IAppointmentRepository, SQLiteAppointmentRepository>();

//add manually
builder.Services.AddAutoMapper(typeof(Program),typeof(Appointment));

//add manually for works patch controller 
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); manually commented

app.UseAuthorization();

app.MapControllers();

app.Run();
