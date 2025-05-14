using HRManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using HRManagementApp.Models; // <-- Update to match your project

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ?? Register the DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<HRManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
