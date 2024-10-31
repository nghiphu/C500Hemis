using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog to log to a file
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add Serilog to the logging pipeline
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

// Add DbContext service to the container
builder.Services.AddDbContext<C500Hemis.Models.HemisContext>(options =>
    options.UseSqlServer("Server=tcp:c500sv.database.windows.net,1433;Database=dbHemisC500;User Id=c500;Password=@Abc1234"));

// Add services for controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Use logger in the application
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Ứng dụng đã khởi động.");

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
