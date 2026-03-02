using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

var builder = WebApplication.CreateBuilder(args);

// SQLite (works on WSL/Linux)
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseSqlite("Data Source=saleswebmvc.db"));

// Add services to the container.
builder.Services.AddControllersWithViews();

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