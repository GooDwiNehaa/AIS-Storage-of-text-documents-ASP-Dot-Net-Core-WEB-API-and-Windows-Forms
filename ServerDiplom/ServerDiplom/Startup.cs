using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ServerDiplom.Models;
using ServerDiplom.BusinessLogic;

namespace ServerDiplom
{
    public class Startup
    {
        private readonly CreateFoldersUploads createFoldersUploads;

        public Startup(IConfiguration configuration, IWebHostEnvironment appEnvironment)
        {
            Configuration = configuration;
            SampleData.Configuration = Configuration;
            createFoldersUploads = new CreateFoldersUploads(appEnvironment);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionSQLServer = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionSQLServer));

            services.AddControllers();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServerDiplom", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServerDiplom v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            createFoldersUploads.CreateFolders();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
