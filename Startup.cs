using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyFirstAPI.Models;

namespace MyFirstAPI
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
            //services.AddDbContext<MyFirstAPIContext>(options => options.UseInMemoryDatabase("MyFirstAPIDb"));
            services.AddDbContext<MyFirstAPIContext>(options => options.UseLazyLoadingProxies().UseSqlServer(@"Data Source = jonas7598.database.windows.net; Initial Catalog=MyFirstAPI;User ID=Mrzeamond;Password=Jomani123"));
            services.AddControllers().AddNewtonsoftJson(options =>
                                                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors(options =>
                        options.AllowAnyHeader()
                               .AllowAnyOrigin()
                               .AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
