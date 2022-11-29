using HealthCare.Doctors.Api.Models;
using HealthCare.Documents.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DocumentsDbContext>();
builder.Services.AddGrpc().AddJsonTranscoding(); ;
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "HealthCare.Documents.Api.xml");
    c.IncludeXmlComments(filePath);
    c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documents GRPC API");
});


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapGrpcService<DocumentsService>();


app.Run();
