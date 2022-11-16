using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DataAcess;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Runtime.ConstrainedExecution;
using FruitApplication.DataAccess.Interfaces;
using FruitApplication.DataAccess.Repository;
using FruitApplication.BusinessLogic.Interfaces;
using FruitApplication.DataAccess.Entities;

namespace FruitApplication
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

            services.AddControllers();
            string DBUUID = Guid.NewGuid().ToString();
            services.AddDbContext<FruitContext>(opt =>
                opt.UseInMemoryDatabase("FruitList" + DBUUID));
            
            
            services.AddControllers(options =>
                {
                    options.Filters.Add(new ProducesAttribute("application/json"));
                }
            );




            services.AddScoped<IFruitRepository, FruitRepository>();

            services.AddScoped<IBLFruit, BLFruit>();

            

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SisViagem", Version = "v1" });


            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=FruitsController}/{action=Index}/{id?}");
                }

            );


        }


    }
}