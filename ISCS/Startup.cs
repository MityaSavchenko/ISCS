using ISCS.Data;
using ISCS.Data.Entities;
using ISCS.Infrastructure;
using ISCS.Models;
using ISCS.Services;
using ISCS.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace ISCS
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            foreach (var service in Kendo.Mvc.KendoServices.GetServices())
                services.Add(service);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.ConfigureDi();

            AutoMapper.Mapper.Initialize(conf =>
                {
                    conf.CreateMap<Area, AreaViewModel>();
                    conf.CreateMap<AreaViewModel, Area>();
                    conf.CreateMap<EquipmentViewModel, Equipment>();
                    conf.CreateMap<Equipment, EquipmentViewModel>();
                    conf.CreateMap<TechCard, TechCardViewModel>();
                    conf.CreateMap<TechCardViewModel, TechCard>();
                    conf.CreateMap<WorkViewModel, Work>();
                    conf.CreateMap<Work, WorkViewModel>();
                    conf.CreateMap<Operation, OperationViewModel>();
                    conf.CreateMap<OperationViewModel, Operation>();
                    conf.CreateMap<EquipmentOperation, OperationViewModel>()
                        .ForMember(x => x.Id, m => m.MapFrom(x => x.OperationId))
                        .ForMember(x => x.Description, m => m.MapFrom(x => x.Operation.Description))
                        .ForMember(x => x.EquipmentOperationId, m => m.MapFrom(x => x.Id))
                        .ForMember(x => x.Name, m => m.MapFrom(x => x.Operation.Name));
                    conf.CreateMap<Hazard, HazardViewModel>();
                    conf.CreateMap<HazardControl, HazardControlViewModel>()
                        .ForMember(x => x.HazardName, m => m.MapFrom(x => x.Hazard.Name));
                    conf.CreateMap<TechCardHazardControl, HazardControlViewModel>()
                        .ForMember(x => x.Id, m => m.MapFrom(x => x.HazardControl.Id))
                        .ForMember(x => x.HazardId, m => m.MapFrom(x => x.HazardControl.Hazard.Id))
                        .ForMember(x => x.Name, m => m.MapFrom(x => x.HazardControl.Name))
                        .ForMember(x => x.HazardName, m => m.MapFrom(x => x.HazardControl.Hazard.Name));
                }
            );
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseKendo(env);
        }
    }
}
