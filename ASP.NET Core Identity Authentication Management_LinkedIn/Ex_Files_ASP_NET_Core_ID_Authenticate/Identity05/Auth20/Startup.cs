using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Auth20.Data;
using Auth20.Models;
using Auth20.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Auth20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();


            //services.AddAuthentication().AddFacebook(options =>
            //{
            //    options.AppId = "263742594511987";
            //    options.AppSecret = "6239ac5d859066d1369c44769b90a324";
            //}).AddGitHub(options =>
            //{
            //    options.ClientId = "f6a2313b9f10ecf0ed1d";
            //    options.ClientSecret = "77ca0f7a2e1c44b055819c88a8edf8c074830fa7";
            //});

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //identity options configuration
            services.Configure<IdentityOptions>(options =>
            {
                //password settings
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;

                //lockout settings
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

                //user settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.Cookie.Name = "auth20_cookie";
                    options.Cookie.HttpOnly = false;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            var cookiePolicyOptions = new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            };
            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
