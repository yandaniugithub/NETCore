using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yak.EFCore.DB;

namespace Yak.EFCore.CodeFirst
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
            //添加数据库上下文服务
            services.AddDbContext<MyDbContext>();
            //services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbConnections"),
            //    p => p.MigrationsAssembly("Yak.EFCore.DB")));
            //services.AddSwaggerGen(m =>
            //{ 
            //    m.SwaggerDoc("v1", new OpenApiInfo() { Title = "swaggertest", Version = "v1" });
            //});
            services.AddCors(m => m.AddPolicy("any", a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            //app.UseSwagger();
            app.UseCors();
            //app.UseSwaggerUI(m => {
            //    m.SwaggerEndpoint("/swagger/v1/swagger.json", "swaggertest");

            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
