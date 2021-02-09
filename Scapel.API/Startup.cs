using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.IO;
using Scapel.Repository.Injections;
using Microsoft.OpenApi.Models;
using Scapel.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Scapel.API
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
           // services.AddDbContext<ScapelContext>(opt => opt
              // .UseSqlServer("Server=localhost; Database=Scapel;User Id=sa; Password=myPassw0rd_12Monica;"));

            services.AddDbContext<ScapelContext>(
    options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("Default"),
            x => x.MigrationsAssembly("Scapel.API")));


            services.AddRepository();
            services.AddControllers();

            //Register Swagger Generator, Defining 1 or more swagger documents
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Scapel API",
                    Description = "API services for Scapel",
                    TermsOfService = new Uri("https://aerglotechnology.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Aerglo Technology",
                        Email = "info@aerglotechnology.com",
                        Url = new Uri("http://aerglotechnology.com/#contact"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Global Surgical Training Challenge",
                        Url = new Uri("https://globalsurgicaltraining.challenges.org/scapel"),
                    }
                });


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            //Enable middleware to server swagger ui(html,js,css)
            //Specify swagger url
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Scapel API V1");
                c.RoutePrefix = string.Empty;
            });

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
