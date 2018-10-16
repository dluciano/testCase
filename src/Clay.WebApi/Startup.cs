using Clay.Core.Implementations;
using Clay.DAL;
using Clay.Services;
using Clay.WebApi.Data;
using IdentityServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Security;
using System.Collections.Generic;

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
            services.AddDbContext<DbContext, WebApiDbContext>(ConfigDb);
            services.AddTransient<IPropertyServices, PropertyServices>();
            services.AddTransient<ILockServices, LockServices>();
            services.AddTransient<ISeed, Clay.WebApi.Seed>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

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

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUi3WithApiExplorer(config =>
                {
                    config.GeneratorSettings.OperationProcessors.TryGet<ApiVersionProcessor>()
                        .IncludedVersions = new[] { "1.0" };
                    config.SwaggerRoute = "/v1/swagger.json";

                    config.GeneratorSettings.Title = "Clay Api";
                    config.GeneratorSettings.Description = "Documentation of the lock API";

                    config.GeneratorSettings.DefaultPropertyNameHandling =
                        PropertyNameHandling.CamelCase;

                    config.GeneratorSettings.DocumentProcessors.Add(
                        new SecurityDefinitionAppender("oauth2", new SwaggerSecurityScheme
                        {
                            Type = SwaggerSecuritySchemeType.OAuth2,
                            Description = "Foo",
                            Flow = SwaggerOAuth2Flow.Implicit,
                            AuthorizationUrl = "https://localhost:45268/connect/authorize",
                            TokenUrl = "https://localhost:45268/connect/token",
                            Scopes = new Dictionary<string, string>
                            {
                                { "openid", "Read access to protected resources" },
                                { "profile", "Read access to protected resources" },
                                { "email", "Write access to protected resources" },
                                { "clayLockApi", "Write access to protected resources" }
                            }
                        })
                    );

                    config.GeneratorSettings.DocumentProcessors.Add(
                        new SecurityDefinitionAppender("apikey", new SwaggerSecurityScheme
                        {
                            Type = SwaggerSecuritySchemeType.ApiKey,
                            Name = "api_key",
                            In = SwaggerSecurityApiKeyLocation.Header,
                        })
                    );
                });

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
