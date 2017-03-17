using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Restaurant.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant
{
    public class Startup
    {
        private IConfigurationRoot Configuration;//add this

        public Startup(IHostingEnvironment env)//add all of this
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => //add all of this
            options.UseSqlServer(
            Configuration["Data:Restaurant:ConnectionString"]));//to here

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:RestaurantIdentity:ConnectionString"]));

            // services.AddIdentity<Member, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddIdentity<Member, IdentityRole>(opts => { opts.Cookies.ApplicationCookie.LoginPath = "/Account/Login"; }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IRestaurantRepository, Menu1Repository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            app.UseMvc(routes => {
                routes.MapRoute(name: "Error", template: "Error",
                    defaults: new { controller = "Error", action = "Error" });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            app.UseMvcWithDefaultRoute();

            RestaurantIdentitySeedData.EnsurePopulated(app);
         
        }
    }
}
