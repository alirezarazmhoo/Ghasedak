using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ghasedak.Service;
using Ghasedak.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Ghasedak
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

            });

            #endregion
            services.AddMvc();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #region DataBaseContext
            services.AddDbContext<Ghasedak.DAL.Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("GhasedakConnection"));
            }

            );
            #endregion

            #region IOc
            services.AddTransient<IBoxIncome, BoxIncomeService>();
            services.AddTransient<ISlider, sliderService>();
            services.AddTransient<IUser, userService>();           
            services.AddTransient<IDischargeRoute, DischargeRouteService>();
            services.AddTransient<IBox, BoxService>();
            services.AddTransient<ICharity, charityService>();
            services.AddTransient<IFlowerCrownType, FlowerCrownTypeService>();
            services.AddTransient<IFlowerCrown, FlowerCrownService>();
            services.AddTransient<IFinancialServiceType, FinancialServiceTypeService>();
            services.AddTransient<IFinancialAid, FinancialAidService>();
            services.AddTransient<ISponsor, SponsorService>();
            services.AddTransient<IOprator, OpratorService>();
            services.AddTransient<IDonator, DonatorService>();
            services.AddTransient<IDeceasedName, DeceasedNameService>();

            #endregion

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var provider = new FileExtensionContentTypeProvider();

            provider.Mappings[".apk"] = "application/vnd.android.package-archive";
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory()),
                ContentTypeProvider = provider
            });
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
           {
               //routes.MapRoute(
               //    name: "areas",
               //    template: "{area:exists}/{controller=User}/{action=Login}/{id?}"

               //);
               routes.MapRoute("Default", "{controller=User}/{action=Login}/{id?}");
               routes.MapRoute("ActionApi", "api/{controller}/{name?}");
           });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
