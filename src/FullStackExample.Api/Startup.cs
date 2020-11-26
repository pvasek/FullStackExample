using FullStackExample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace FullStackExample.Api
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
            services.AddCors();
            services.AddControllers();
            //services.AddSingleton<IRepository<Entities.Task>, InMemoryTaskRepository<Entities.Task>>();
            var db = new InMemoryTaskRepository<Entities.Task>();
            db.SaveAsync(new Entities.Task { Id = new System.Guid("4ce7f15f-7b35-4488-9164-ba99039ddaa7"), Name = "task1" }).Wait();
            db.SaveAsync(new Entities.Task { Id = new System.Guid("b5d87f6d-ed8f-45ae-8046-82ac5e0ddce0"), Name = "task2" }).Wait();
            services.AddSingleton<IRepository<Entities.Task>>(db);
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

            app.UseCors(options => {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
