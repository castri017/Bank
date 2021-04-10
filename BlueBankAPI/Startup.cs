using BlueBankApi.Core.Interfaces;
using BlueBankApi.Core.Services;
using BlueBankApi.Infrastructure.Data;
using BlueBankApi.Infrastructure.Filters;
using BlueBankApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBankAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors();

            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });
            services.AddDbContext<BlueBankContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlueBank")));

            services.AddTransient<IPersonaServices, PersonaServices>();
            services.AddTransient<ITransaccionServices, TransaccionServices>();
            services.AddTransient<ICuentaAhorroServices, CuentaAhorroServices>();
            services.AddTransient<ITipoIdentificacionServices, TipoIdentificacionServices>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<ICuentaAhorroRepository, CuentaAhorroRepository>();
            services.AddTransient<ITransacionRepository, TransaccionRepository>();
            services.AddTransient<ITipoIdentificacionRepository, TipoIdentificacionRepository>(); 

            // OPENAPI SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlueBank API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options =>
            {
                options.WithOrigins("*");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "BlueBank");
            });
        }
    }
}
