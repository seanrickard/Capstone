using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.DAL.Repos;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Service.Filters;

namespace PurchaseReq.Service
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Sets up MVC and JSON Formatting
            services.AddMvcCore(config =>
                    config.Filters.Add(new PurchaseReqExceptionFilter(_env.IsDevelopment())))
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                })
                //This below code fixed JSON not displaying NAV Props -> https://stackoverflow.com/questions/41373878/json-response-does-not-contain-all-the-navigation-properties-entityframework-cor
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
                    

            //Sets up Cors for JS Librarys
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials(); });
            });


            //Sets up DB Connection from appsettings.json
            services.AddDbContext<PurchaseReqContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("PurchaseReq")));

            services.AddIdentity<Employee, IdentityRole>()
                .AddEntityFrameworkStores<PurchaseReqContext>()
                .AddDefaultTokenProviders();

            //Repo Set up
            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<ICampusRepo, CampusRepo>();
            services.AddScoped<IRoomRepo, RoomRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IDivisionRepo, DivisionRepo>();
            services.AddScoped<IBudgetCodeRepo, BudgetCodeRepo>();
            services.AddScoped<IBudgetAmountRepo, BudgetAmountRepo>();
            services.AddScoped<IEmployeeBudgetCodeRepo, EmployeeBudgetCodeRepo>();
            services.AddScoped<IApprovalRepo, ApprovalRepo>();
            services.AddScoped<ISupervisorApproval, SupervisorApprovalRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IRequestRepo, RequestRepo>();
            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<IVendorRepo, VendorRepo>();
            services.AddScoped<IAttachmentRepo, AttachmentRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IStatusRepo, StatusRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PurchaseReqContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                DbInitializer.InitializeData(db);
                
            }

            app.UseAuthentication();
                

            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}
