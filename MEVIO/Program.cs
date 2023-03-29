//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.EntityFrameworkCore;
//using MEVIO.Models;
//using Microsoft.AspNetCore.Authorization;

//var builder = WebApplication.CreateBuilder(args);

//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<MEVIOContext>(options => options.UseSqlServer(connection));

////Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Services.AddSession();
////builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

//////



//////
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
//{
//    options.LoginPath = "/Registry/Login";
//});


////builder.Services.AddAuthorization(options =>
////{
////    options.FallbackPolicy = new AuthorizationPolicyBuilder()
////        .RequireAuthenticatedUser()
////        .Build();
////});
////builder.Services.AddAuthorization();


//var app = builder.Build();


//app.UseSession();//ϲ��������� ��Ѳ�

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


//app.UseAuthentication();
//app.UseAuthorization();

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Registry}/{action=Login}/{id?}");

//app.Run();


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MEVIO.Models;



var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MEVIOContext>(options => options.UseSqlServer(connection));

//Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

////



////
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAuthorization();


var app = builder.Build();


app.UseSession();//ϲ��������� ��Ѳ�

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
