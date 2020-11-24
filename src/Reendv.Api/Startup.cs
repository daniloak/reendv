using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reendv.Domain.Handlers;
using Reendv.Domain.Repositories;
using Reendv.Infra.Contexts;
using Reendv.Infra.Repositories;

namespace Reendv.Api
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
            services.AddControllers();

            //services.AddDbContext<ReendvContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<ReendvContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();

            services.AddTransient<CustomerHandler>();
            services.AddTransient<ServiceHandler>();
            services.AddTransient<AppointmentHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
