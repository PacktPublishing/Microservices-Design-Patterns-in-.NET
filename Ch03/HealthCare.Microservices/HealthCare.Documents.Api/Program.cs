using HealthCare.Doctors.Api.Models;
using HealthCare.Documents.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DocumentsDbContext>();
builder.Services.AddGrpc();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapGrpcService<DocumentsService>();



app.Run();
