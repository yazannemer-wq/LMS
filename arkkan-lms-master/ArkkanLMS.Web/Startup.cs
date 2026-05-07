using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArkkanLMS.Core.Interfaces;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ArkkanLMS.Application.Services;
using ArkkanLMS.Application.Services.AuthenticationService;
using ArkkanLMS.Web.Localization;
using Microsoft.AspNetCore.Authorization;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Web.Authorization;
using Serilog;

namespace ArkkanLMS.Web
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
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddHttpContextAccessor();
            services.AddScoped<LocaleProvider>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            // Add authentication with a default scheme to support Forbid() calls
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Status/403";
                });

            services.AddAuthorization(options =>
            {
                foreach (PermissionType perm in System.Enum.GetValues(typeof(PermissionType)))
                {
                    options.AddPolicy(Permissions.Policy(perm), policy =>
                        policy.Requirements.Add(new PermissionRequirement(perm)));
                }
            });

            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            // Maintenance gate (toggle via appsettings: App:MaintenanceMode=true)
            app.Use(async (context, next) =>
            {
                var maintenanceEnabled = Configuration.GetValue<bool>("App:MaintenanceMode");
                if (maintenanceEnabled)
                {
                    var path = context.Request.Path;
                    var isMaintenancePage = path.StartsWithSegments("/Maintenance");
                    var isStatusPage = path.StartsWithSegments("/Status");
                    var isStatic = path.StartsWithSegments("/css")
                                   || path.StartsWithSegments("/js")
                                   || path.StartsWithSegments("/lib")
                                   || path.StartsWithSegments("/favicon");

                    if (!isMaintenancePage && !isStatusPage && !isStatic)
                    {
                        context.Response.StatusCode = 503;
                        context.Request.Path = "/Maintenance";
                    }
                }

                await next();
            });

            // Add authentication middleware before authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Friendly status pages for 401/403/404, etc.
            app.UseStatusCodePagesWithReExecute("/Status/{0}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
                dbContext.SeedData();
            }
        }
    }
}


