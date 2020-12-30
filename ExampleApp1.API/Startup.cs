using ExampleApp1.API.Data;
using ExampleApp1.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLibrary.Configuration;
using SharedLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.OpenApi.Models;

namespace ExampleApp1.API
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
            services.AddDbContext<ExampleApp1Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer2"), opt =>
                {
                    // migration iþlemleri nerde gerçekleþicek ise o konumu belirtiyoruz.
                    opt.MigrationsAssembly("ExampleApp1.API");
                });
            });
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockService, StockService>();

           
            services.Configure<CustomTokenOption>(Configuration.GetSection("TokenOption"));
            var tokenOptions = Configuration.GetSection("TokenOption").Get<CustomTokenOption>();

            services.AddCustomTokenAuth(tokenOptions);

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("doc", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Exampleapp1 API",
                    Description = "Exampleapp1 API Document",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "sametirkoren@gmail.com",
                        Name = "Samet Irkören",
                        Url = new Uri("https://sametirkoren.com.tr")
                    }
                });
                opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authentication",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Bearer {token}"
                });
            });
            services.AddControllers();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/doc/swagger.json", "AuthServer API");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}