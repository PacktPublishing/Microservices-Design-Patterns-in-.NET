using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddSingletonDefinedAggregator<PatientAppointmentAggregator>()

    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    });

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

await app.UseOcelot();
app.UseHttpsRedirection();

app.Run();

public class PatientAppointmentAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
    {
        var patient = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
        var appointments = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

        var contentBuilder = new StringBuilder();
        contentBuilder.Append(patient);
        contentBuilder.Append(appointments);

        var response = new StringContent(contentBuilder.ToString())
        {
            Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
        };

        return new DownstreamResponse(response, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
    }
}
