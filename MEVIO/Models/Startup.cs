using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace MEVIO.Models
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            // Добавление сервиса для доступа к настройкам в appsettings.json
//            services.AddSingleton(Configuration);

//            services.AddControllersWithViews();

//            // Добавление сервисов для аутентификации через Google и проверки данных в базе данных
//            services.AddAuthentication(options =>
//            {
//                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//            })

//.AddCookie("MyScheme", options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.AccessDeniedPath = "/Account/AccessDenied";
//})
//.AddGoogle(options =>
//{
//    options.ClientId = Configuration["Google:ClientId"];
//    options.ClientSecret = Configuration["Google:ClientSecret"];
//    options.Scope.Add("email");
//    options.SaveTokens = true;
//});

//            // Добавление сервиса для доступа к базе данных
//            services.AddDbContext<MEVIOContext>();

//        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
