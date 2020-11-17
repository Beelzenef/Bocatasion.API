using Bocatasion.API.Bocatasion.API.Data;
using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Bocatasion.API.Data.Repositories;
using Bocatasion.API.Data;
using Bocatasion.API.Data.Contracts;
using Bocatasion.API.Services;
using Bocatasion.API.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Bocatasion.API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAll", options => options.AllowAnyOrigin().AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bocatasion.API",
                    Description = "... porque no se hace sola, hay que hacerla",
                    Contact = new OpenApiContact
                    {
                        Name = "Elena G",
                        Email = "elena.guzbla@gmail.com",
                        Url = new Uri("https://twitter.com/Beelzenef_"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<Context>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IDatabaseContext, Context>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ISandwichRepository, SandwichRepository>();
            services.AddTransient<ISandwichService, SandwichService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bocatasion.API V1");
            });

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
