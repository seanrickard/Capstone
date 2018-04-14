using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PurchaseReq.DAL.EF;
using PurchaseReq.Models.Entities;
using PurchaseReq.MVC.Configuration;
using PurchaseReq.MVC.WebServiceAccess;
using PurchaseReq.MVC.WebServiceAccess.Base;

namespace PurchaseReq.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_ => _configuration);
            services.AddSingleton<IWebServiceLocator, WebServiceLocator>();
            services.AddSingleton<IWebApiCalls, WebApiCalls>();

            //Sets up DB Connection from appsettings.json
            services.AddDbContext<PurchaseReqContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("PurchaseReq")));

            services.AddIdentity<Employee, IdentityRole>()
                .AddEntityFrameworkStores<PurchaseReqContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Login}/{id?}");
            });
        }
    }
}
