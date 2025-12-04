using HrPlatform.Infrastructure.Persistence.Postgre.Extensions;
using HrPlatform.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("swagger/v1/index.html", "V1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

await app.RunAsync();