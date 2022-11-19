using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StudentManager.WebApp.Areas.Identity.Data;
using StudentManager.WebApp.Controllers;
using StudentManager.WebApp.Areas;
using Fitness.Infrastracture;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddTransient<IShortedUserController, ShortenUserController>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(ctx => ctx.UseLazyLoadingProxies());
builder.Services.AddRazorPages();

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<CreatedUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
