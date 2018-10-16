using Clay.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;

namespace Clay.WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly string _connectionString;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
            _connectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebApiDbContext>(ConfigDb);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:45268";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "clayLockApi";
                });
            services.AddCors(options =>
                {
                    // this defines a CORS policy called "default"
                    options.AddPolicy("default", policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });
            if (_env.IsDevelopment())
            {
                services.AddSwagger();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3WithApiExplorer(settings =>
                {
                    settings.GeneratorSettings.DefaultPropertyNameHandling =
                        PropertyNameHandling.CamelCase;
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("default");
            app.UseAuthentication();

            app.UseMvc();
        }
        private void ConfigDb(DbContextOptionsBuilder options)
        {
            if (_env.IsDevelopment())
                options.UseSqlServer(_connectionString);
            else if (_env.EnvironmentName == "Docker")
                options.UseSqlite(_connectionString);
        }
    }
}
