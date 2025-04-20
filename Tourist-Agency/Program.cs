using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;
using TouristAgencyAPI.Repositories;
using TouristAgencyAPI.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("https://localhost:7276");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITouristRouteRepository, TouristRouteRepository>();
builder.Services.AddScoped<ITouristRouteService, TouristRouteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();