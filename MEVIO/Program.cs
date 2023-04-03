
using Microsoft.EntityFrameworkCore;
using MEVIO.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MEVIOContext>(options => options.UseSqlServer(connection));

//Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//.AddCookie(options =>
//{
//    options.LoginPath = "/Registry/Index";
//    options.AccessDeniedPath = "/AccessDenied";
//    options.ExpireTimeSpan = TimeSpan.FromDays(7);
//});



////
//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//    }).AddGoogle(options =>
//    {
//        options.ClientId = "715700270542-m2iv2jqmaue49o43d969evbivc5jqj1s.apps.googleusercontent.com";
//        options.ClientSecret = "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";
//    }) ;


////
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAuthorization();


var app = builder.Build();


app.UseSession();//Ï²ÄÊËÞ×ÅÍÍß ÑÅÑ²¯

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

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registry}/{action=Index}/{id?}");

app.Run();
