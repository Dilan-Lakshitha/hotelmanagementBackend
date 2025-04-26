using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Application.Services;
using hotelmanagementBackend.Infrastructure.Data;
using hotelmanagementBackend.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAgencyServiceRepository,AgencyService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IGuideService, GuideService>();
builder.Services.AddScoped<IGuideRepository, GuideRepository>();
builder.Services.AddScoped<IItineraryService, ItineraryService>();
builder.Services.AddScoped<IItineraryRepository, ItineraryRepository>();
builder.Services.AddScoped<ILocationTicketRepository, LocationTicketRepository>();
builder.Services.AddScoped<ILocationTicketService, LocationTicketService>();
builder.Services.AddScoped<ITourPlanRepository, TourPlanRepository>();
builder.Services.AddScoped<ITourPlanService, TourPlanService>();
builder.Services.AddScoped<ITravelerRepository, TravelerRepository>();
builder.Services.AddScoped<ITravelerService, TravelerService>();
builder.Services.AddScoped<IBookingTourRepository , BookingTourRepository>();
builder.Services.AddScoped<IBookingTourService, BookingTourService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");


app.UseAuthorization();

app.MapControllers();

app.Run();
