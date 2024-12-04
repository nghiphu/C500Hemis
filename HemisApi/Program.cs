using HemisApi;
using HemisApi.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// C?u h�nh DbContext cho SQL Server
builder.Services.AddDbContext<DbHemisC500Context>(options =>
    options.UseSqlServer("Server=10.0.28.54;Database=dbHemisC500;Trusted_Connection=True;Encrypt=false;User Id=c500;Password=@Abc1234")
    //options.UseSqlServer("Server=tcp:c500sv.database.windows.net,1433;Database=dbHemisC500;User Id=c500;Password=@Abc1234")
);

// C?u h�nh localization ?? h? tr? ti?ng Vi?t
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("vi-VN") };
    options.DefaultRequestCulture = new RequestCulture("vi-VN");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Th�m c�c d?ch v? v�o container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// C?u h�nh pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
