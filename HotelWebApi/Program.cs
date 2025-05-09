using Hangfire;
using HotelBusinessLayer.Abstract;
using HotelBusinessLayer.Concrete;
using HotelDataAccessLayer.Abstract;
using HotelDataAccessLayer.Concrate;
using HotelDataAccessLayer.EntityFramework;
using HotelDataAccessLayer.Seeders;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#region ClassMapping

builder.Services.AddDbContext<HotelContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();


builder.Services.AddScoped<IHomeService, HomeManager>();
builder.Services.AddScoped<IHomeDal, EfHomeDal>();

builder.Services.AddScoped<IHotelServService, HotelServManager>();
builder.Services.AddScoped<IHotelServ, EfHotelServDal>();

builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<IReservationDal, EfReservationDal>();

builder.Services.AddScoped<IRoomTypeService, RoomTypeManager>();
builder.Services.AddScoped<IRoomTypeDal, EfRoomTypeDal>();

builder.Services.AddScoped<IReservationDetailService, ReservationDetailManager>();
builder.Services.AddScoped<IReservationDetailDal, EfReservationDetailDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<IRoomAvailabilityService, RoomAvailabilityManager>();
builder.Services.AddScoped<IRoomAvailabilityDal, EfRoomAvailabilityDal>();

#endregion

 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(x => x.UseSqlServerStorage("YourConnectionString"));
builder.Services.AddHangfireServer();


var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    RoomAvailabilitySeeder.SeedInitialAvailability(scope.ServiceProvider);
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard(); // Opsiyonel: Dashboard’a eriþmek için
 
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
