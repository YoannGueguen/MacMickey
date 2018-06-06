using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MacMickey.Dal;
using MacMickey.DomainModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Website.Data;
using Website.Services;

namespace MacMickeyWeb
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

            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

            services.AddDbContext<MacContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MacMickeyDb")));

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<BasketCardsService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //InitializeDatabase(app);

                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //    private void InitializeDatabase(IApplicationBuilder app)
        //    {
        //        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //        {
        //            scope.ServiceProvider.GetRequiredService<MacContext>().Database.Migrate();
        //}
        //    }
    }
}
