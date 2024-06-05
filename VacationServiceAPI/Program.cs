using System.Text.Json.Serialization;
using VacationService.Application;
using VacationService.Infrastructure;
using VacationServiceAPI;
using VacationServiceAPI.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureLogging(builder.Configuration);

builder.Services.ConfigureApplicationServices();

builder.Services.ConfigureDataBase(builder.Configuration);

builder.Services.AddInfrastructureServices();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

