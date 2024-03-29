using HealthCare.Appointments.Api.Constants;
using HealthCare.Appointments.Api.Service;
using MediatR;
using HealthCare.Appointments.Api.Repositories;
using HealthCare.Appointments.Api.Services;
using MassTransit;
using HealthCare.Appointments.Api.Configuraitons;
using System.Reflection;
using HealthCare.Appointments.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentsDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ApiEndpoints>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();

builder.Services.AddTransient(typeof(IHttpRepository<>), typeof(HttpRepository<>));
builder.Services.AddTransient<IDoctorsApiRepository, DoctorsApiRepository>();
builder.Services.AddTransient<IPatientsApiRepository, PatientsApiRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
