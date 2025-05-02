using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;
using TouristAgencyAPI.Repositories;
using TouristAgencyAPI.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("https://localhost:7276");

builder.Services.AddDbContext<TouristAgencyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITouristRouteRepository, TouristRouteRepository>();
builder.Services.AddScoped<ITouristRouteService, TouristRouteService>();

builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();

builder.Services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();