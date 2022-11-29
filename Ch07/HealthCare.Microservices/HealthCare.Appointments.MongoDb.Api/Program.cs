using HealthCare.Appointments.Api.Models;
using HealthCare.Appointments.MongoDb.Api.Models;
using HealthCare.Appointments.MongoDb.Api.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("AppointmentsDatabase"));
builder.Services.AddSingleton<AppointmentsService>();

builder.Services.AddControllers()
        .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseDatabaseCheckMiddleware();

app.Run();


public static class CutomMiddleware
{
    public static void UseDatabaseCheckMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<MongoDBConnectionCheck>();
    }
}

public class MongoDBConnectionCheck
{
    private readonly RequestDelegate _next;

    public MongoDBConnectionCheck(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (TimeoutException tx)
        {
            throw new Exception("Be sure to configure the MongoDB connection string in appsettings.json");
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}