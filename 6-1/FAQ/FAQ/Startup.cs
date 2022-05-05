using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FAQ.Models;

namespace FAQ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<FAQContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FAQContext")));
            services.AddRouting(options => { options.LowercaseUrls = true; options.AppendTrailingSlash = true; });
        }

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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "topic_category",
                    pattern: "{controller=Home}/{action=Index}/topic/{topic}/category/{category}");
                endpoints.MapControllerRoute(
                    name: "topic",
                    pattern: "{controller=Home}/{action=Index}/topic/{topic}");
                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "{controller=Home}/{action=Index}/category/{category}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

            });
        }
    }
}
