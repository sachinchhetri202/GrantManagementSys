using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Grant_Management_System.Data;
using Grant_Management_System.Models;
var builder = WebApplication.CreateBuilder(args);

//Comment for test commit by CJ 9/13/24

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Grant_Management_SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Grant_Management_SystemContext") ?? throw new InvalidOperationException("Connection string 'Grant_Management_SystemContext' not found.")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

//Seed database with users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedUsers.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//use for settign session
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
