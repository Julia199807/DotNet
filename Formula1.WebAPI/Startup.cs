using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Formula1.BLL.Contracts;
using Formula1.BLL.Implementation;
using Formula1.DataAccess.Context;
using Formula1.DataAccess.Contracts;
using Formula1.DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Formula1.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(IF1TeamCreateService),typeof(F1TeamCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IF1TeamGetService),typeof(F1TeamGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IF1TeamUpdateService),typeof(F1TeamGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRiderCreateService),typeof(RiderCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRiderGetService),typeof(RiderGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRiderUpdateService),typeof(RiderUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(IF1TeamDataAccess), typeof(F1TeamDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRiderDataAccess), typeof(RiderDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<F1TeamContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Formula1")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<F1TeamContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}