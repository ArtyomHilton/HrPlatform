using HrPlatform.Common;
using HrPlatform.Web.Extensions;
using HrPlatform.Web.Middleware;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Application starting...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddSerilog();

    builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDependencyInjection(builder.Configuration);

    //builder.Services.AddApiVersioning(options =>
    //{
    //    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    //    options.DefaultApiVersion = new ApiVersion(1);
    //}).AddApiExplorer(options =>
    //{
    //    options.GroupNameFormat = "'v'V";
    //    options.SubstituteApiVersionInUrl = true;
    //});

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("swagger/v1/swagger.json", "V1");
        options.RoutePrefix = string.Empty;
    });

    await app.ApplyMigrationsAsync();

    app.UseHttpsRedirection();

    app.MapEndpoints();

    await app.RunAsync();
}
catch(Exception exception)
{
    Log.Fatal("Critical error: {Exception} | {Message}", exception.GetType(), exception.Message);
}
finally
{
    await Log.CloseAndFlushAsync();
}