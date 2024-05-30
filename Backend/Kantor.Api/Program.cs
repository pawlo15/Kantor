using Kantor.Api.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting web application");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

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

    app.UseSerilogRequestLogging();

    app.UseCors("MyPolicy");

    app.RunAuthorization();

    app.MapControllers();

    app.UseOpenApi();

    app.UseExceptionExtension();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    await Log.CloseAndFlushAsync();
}

