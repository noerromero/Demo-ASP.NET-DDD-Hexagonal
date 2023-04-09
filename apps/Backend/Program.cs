using Appointments.Calendars.Domain;
using Appointments.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Appointments.Calendars.Infrastructure.Persistence;
using SharedOffice.Shared.Infrastructure.Persistence.EntityFramework;
using SharedOffice.Users.Domain;
using SharedOffice.Users.Infrastructure.Persistence;

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
builder.Services.AddDbContext<SharedOfficeContext>(x => {
    x.UseSqlite(builder.Configuration.GetConnectionString("SharedOfficeConnection"));
});

//add manually
builder.Services.AddScoped<ICalendarRepository, SQLiteCalendarRepository>();
builder.Services.AddScoped<IUserRepository, SQLiteUserRepository>();

//add manually
builder.Services.AddAutoMapper(typeof(Program),typeof(Appointment));

//add manually for works patch controller 
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson();

//add manually cors for Frontend
builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyHeader()
          .AllowAnyMethod()
          .WithOrigins("https://localhost:7210");
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); manually commented

app.UseAuthorization();

//Add manually cors for frontend
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
