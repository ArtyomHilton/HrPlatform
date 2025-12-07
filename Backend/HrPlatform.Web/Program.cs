using Asp.Versioning;
using HrPlatform.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

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