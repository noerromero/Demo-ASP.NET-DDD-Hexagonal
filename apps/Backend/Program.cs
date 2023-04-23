using FrontOffice.Calendars.Domain;
using FrontOffice.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using FrontOffice.Calendars.Infrastructure.Persistence;
using SharedOffice.Shared.Infrastructure.Persistence.EntityFramework;
using SharedOffice.Users.Domain;
using SharedOffice.Users.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*//add manually
builder.Services.AddDbContext<FrontOfficeContext>(x => {
    x.UseSqlite(builder.Configuration.GetConnectionString("FronOfficeConnection"));
});*/

builder.Services.AddDbContext<FrontOfficeContext>(x => {
    x.UseMySQL(builder.Configuration.GetConnectionString("FronOfficeConnection"));
});

//add manually
builder.Services.AddDbContext<SharedOfficeContext>(x => {
    x.UseSqlite(builder.Configuration.GetConnectionString("SharedOfficeConnection"));
});

//add manually
//builder.Services.AddScoped<ICalendarRepository, SQLiteCalendarRepository>(); Use this line for sqlite
builder.Services.AddScoped<ICalendarRepository, MySQLCalendarRepository>();
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
