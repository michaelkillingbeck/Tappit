using API.DataAccess.EFCore;
using API.DataAccess.EFCore.Repositories;
using API.DataAccess.Interfaces;
using API.Interfaces.Services;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
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
            services.AddSwaggerGen();

            services.AddDbContext<TappitTechnicalTestContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TappitTechnicalTest")));

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ISportSummaryService, SportSummaryService>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ISportRepository, SportRepository>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
