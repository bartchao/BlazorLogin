using BlazorLogin.Data;
using BlazorLogin.Service;
using BlazorLogin.Shared;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorLogin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<TEMPLATE20Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalDB"));
                options.EnableSensitiveDataLogging();
            });
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.AccessDeniedPath = "/you-are-not-allowed-page";
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
            });
            services.AddScoped<AuthService>();
            services.AddScoped<NavMenuBuilder>();
            services.AddScoped<IDataServiceFactory,DataServiceFactory>();
            services.AddScoped<SessionStateProvider>();
            services.AddScoped<ITranslator,Translator>();
            services.AddTelerikBlazor();
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
            app.UseHsts();
        }

        var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(locOptions.Value);


        app.UseHttpsRedirection();
        app.UseStaticFiles();
        //app.UseCookiePolicy(CookiePolicyOptions);
        app.UseRouting();
        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");

        });
    }
}
}
