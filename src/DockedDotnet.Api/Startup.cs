using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace DockedDotnet.Api
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
            var databaseSettings = Configuration.GetSection("DockedDotnetDatabaseSettings").Get<DatabaseSettings>();
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var database = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);
            services.AddSingleton(database);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DockedDotnet.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(c => c
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DockedDotnet.Api v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
