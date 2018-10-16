using System;
using System.Reflection;
using Clay.Core.Implementations;
using Clay.DAL;
using Clay.Entities;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            _connectionString = Configuration.GetConnectionString("DefaultConnection");
            _migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
        }

        private IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        private readonly string _connectionString;
        private readonly string _migrationsAssembly;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureInjerctors(services);

            ConfigureIdentity(services);

            services
                .AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddSingleton<IEmailSender, EmailSenderFake>();
        }

        private void ConfigDb(DbContextOptionsBuilder options)
        {
            if (Environment.IsDevelopment())
                options.UseSqlServer(_connectionString, sql => sql.MigrationsAssembly(_migrationsAssembly));
            else if (Environment.EnvironmentName == "Docker")
                options.UseSqlite(_connectionString, sql => sql.MigrationsAssembly(_migrationsAssembly));
        }

        private void ConfigureInjerctors(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(ConfigDb);

            services.AddTransient<ISeed, Seed>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ISecurityService, SecurityService>();

            services.AddTransient<IRepository<Client>, Repository<Client>>(serviceProvider =>
            {
                return new Repository<Client>(
                    serviceProvider.GetRequiredService<ConfigurationDbContext>(),
                    serviceProvider.GetRequiredService<ISecurityService>());
            });
            services.AddTransient<IRepository<ApiResource>, Repository<ApiResource>>(serviceProvider =>
            {
                return new Repository<ApiResource>(
                    serviceProvider.GetRequiredService<ConfigurationDbContext>(),
                    serviceProvider.GetRequiredService<ISecurityService>());
            });
            services.AddTransient<IRepository<IdentityResource>, Repository<IdentityResource>>(serviceProvider =>
            {
                return new Repository<IdentityResource>(
                    serviceProvider.GetRequiredService<ConfigurationDbContext>(),
                    serviceProvider.GetRequiredService<ISecurityService>());
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                })
                // this adds the config data from DB (clients, resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => ConfigDb(b);
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => ConfigDb(b);

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    //options.DefaultSchema = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                });

            if (Environment.IsDevelopment())
                builder.AddDeveloperSigningCredential();
            else
                throw new Exception("need to configure key material");

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "https://localhost:45268";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = ClientRepositoryExtensions.DoorLocksApiName;
                    });
            services.AddCors(options =>
                {
                    // this defines a CORS policy called "default"
                    options.AddPolicy("default", policy =>
                    {
                        policy.WithOrigins("http://localhost:3000", "https://localhost:5001")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("default");
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}