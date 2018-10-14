using System;
using System.Reflection;
using Clay.DAL;
using Clay.Entities;
using IdentityServer4;
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
        }

        private IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            ConfigureInjerctors(services, connectionString, migrationsAssembly);

            ConfigureIdentity(services, connectionString, migrationsAssembly);

            services.AddMvc()
                .AddRazorPagesOptions(options => { options.AllowAreas = true; });

            services.AddSingleton<IEmailSender, EmailSenderFake>();
        }

        private static void ConfigureInjerctors(IServiceCollection services, string connectionString,
            string migrationsAssembly)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));

            services.AddTransient<ISeed, Seed>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IRepository<Client>, Repository<Client>>(serviceProvider =>
            {
                return new Repository<Client>(serviceProvider.GetRequiredService<ConfigurationDbContext>());
            });
            services.AddTransient<IRepository<ApiResource>, Repository<ApiResource>>(serviceProvider =>
            {
                return new Repository<ApiResource>(serviceProvider.GetRequiredService<ConfigurationDbContext>());
            });
            services.AddTransient<IRepository<IdentityResource>, Repository<IdentityResource>>(serviceProvider =>
            {
                return new Repository<IdentityResource>(
                    serviceProvider.GetRequiredService<ConfigurationDbContext>());
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private void ConfigureIdentity(IServiceCollection services, string connectionString, string migrationsAssembly)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
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
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.DefaultSchema = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                });

            if (Environment.IsDevelopment())
                builder.AddDeveloperSigningCredential();
            else
                throw new Exception("need to configure key material");

            services.AddAuthentication();
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
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}