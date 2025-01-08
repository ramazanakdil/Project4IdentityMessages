using Microsoft.AspNetCore.Authentication.Cookies;
using Project4IdentityMessages.Models;
using Project4IdentityMessages_BusinessLayer.Container;
using Project4IdentityMessages_DataAccessLayer.Context;
using Project4IdentityMessages_EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<IdentityMailContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityMailContext>().AddErrorDescriber<CustomIdentityErrorValidator>();


builder.Services.ContainerDependencies();




builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Giriþ sayfasý
        options.LogoutPath = "/Message/Logout"; // Çýkýþ iþlemi
    });


builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
