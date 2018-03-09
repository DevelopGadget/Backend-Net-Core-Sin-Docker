using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.IRepositorio;
using Web.Models;
using Web.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Web
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
            services.AddMvc();
            services.Configure<Settings>(o => { o.configuration = (IConfigurationRoot) Configuration; });
            services.AddTransient<IEquipo, Equipo_Repositorio>();
            services.AddTransient<IJugadores, Jugadores_Repositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(data =>
            data.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseMvc( Routes => {
                    Routes.MapRoute(
                        name: "Default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                    );
                }
);
        }
    }
}
