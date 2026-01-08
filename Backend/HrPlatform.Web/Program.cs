using HrPlatform.Web.Extensions;
using HrPlatform.Web.Middleware;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("Application", nameof(HrPlatform))
    .WriteTo.Async(l =>
        l.Console(restrictedToMinimumLevel: LogEventLevel.Information))
    .CreateBootstrapLogger();

try
{
    Log.Information("Application starting...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddProblemDetails();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    builder.Services.AddDependencyInjection(builder.Configuration);
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseExceptionHandler();
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenAPI v1");
    });

    app.UseHttpsRedirection();

    await app.RunAsync();
}
catch (Exception exception)
{
    Log.Error("An error occured while starting application: \n Error: {Error} | Message: {Message}", 
        exception.GetType().FullName, exception.Message);
}
finally
{
    await Log.CloseAndFlushAsync();
}