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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}