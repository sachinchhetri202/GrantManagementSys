using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Grant_Management_System.Data;
var builder = WebApplication.CreateBuilder(args);

//Test Comment Wesley
// Sachubn
//Comment for test commit by CJ 9/13/24

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Grant_Management_SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Grant_Management_SystemContext") ?? throw new InvalidOperationException("Connection string 'Grant_Management_SystemContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
