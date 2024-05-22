using Kantor.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddMapper();

builder.Services.AddControllers();

builder.Services.AddDatabase(builder);

builder.Services.AddServices();

builder.Services.AddMediatREntension();

builder.Services.AddAuthenticationExtension(builder);

builder.Services.AddAuthorizationExtension();

builder.Services.AddSwaggerExtension();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("MyPolicy");

app.RunAuthorization();

app.MapControllers();

app.UseOpenApi();

app.UseExceptionExtension();

app.Run();
