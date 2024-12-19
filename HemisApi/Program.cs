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
string mode = "Local"; //Đổi sang Remote nếu tự chạy API
builder.Services.AddDbContext<DbHemisC500Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(mode) ?? throw new Exception("Không tồn tại connection string"))
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
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
