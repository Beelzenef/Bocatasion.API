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
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
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

            app.UseCors(options => options.AllowAnyOrigin());
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
