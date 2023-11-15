using BusStorage.Application.Repositories;
using BusStorage.Application.Services;
using BusStorage.Dal;
using BusStorage.Domain.Aggregates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DapperContext>();

builder.Services.AddScoped<CityServices>();
builder.Services.AddScoped<CityRepository>();
builder.Services.AddScoped<BusRepository>();
builder.Services.AddScoped<BusService>();

builder.Services.AddScoped<BusStopService>();
builder.Services.AddScoped<BusStopRepository>();

builder.Services.AddScoped<BusRouteService>();
builder.Services.AddScoped<BusRouteRepository>();

builder.Services.AddScoped<ScheduleRepository>();
builder.Services.AddScoped<ScheduleService>();

builder.Services.AddScoped<IUserActionsRepository, UserActionsRepository>();
builder.Services.AddScoped<UserActionsService>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
