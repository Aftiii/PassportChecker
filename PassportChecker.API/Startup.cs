using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PassportChecker.API.Services;
using PassportChecker.API.Interfaces;
using AutoMapper;
using PassportChecker.API.Utility;
using PassportChecker.Common.BusinessLogic;
using PassportChecker.Common.BusinessLogic.Interfaces;


namespace PassportChecker.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //IoC
            services.AddScoped<IGendersService, GendersService>();
            services.AddScoped<INationalitiesService, NationalitiesService>();
            services.AddScoped<IParseMzrLine2, ParseMzrLine2>();
            services.AddScoped<IMzrValidator, MzrValidator>();

            //Automapper
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.WithOrigins("https://localhost:44387").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
