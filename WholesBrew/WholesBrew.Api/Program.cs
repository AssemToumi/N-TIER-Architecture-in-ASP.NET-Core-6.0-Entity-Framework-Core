
using Microsoft.AspNetCore.Builder;
using WholesBrew.Api.Configuration;
using WholesBrew.Api.Middelwares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddJsonConfigurationProvider(
    ("appsettings.json", false, true),
    ($"appsettings.{builder.Environment.EnvironmentName}.json", true, true),
    ("appsettings.serilog.json", false, true),
    ($"appsettings.serilog.{builder.Environment.EnvironmentName}.json", true, true));

builder.Services.AddConfiguration(builder.Configuration);

WebApplication app = builder.Build();

// Enable CORS
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);

app.UseMiddleware<WholesBrewExceptionHandlerMiddelware>();

app.UsePathBase("/wholesbrew-be");
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
