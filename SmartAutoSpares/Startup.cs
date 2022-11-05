using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartAutoSpares.Context;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Services.Authentication;
using SmartAutoSpares.Services.Validations.AuthenticationValidation;
using SmartAutoSpares.Hubs.Feeds;
using SmartAutoSpares.Hubs.Tutors;
using SmartAutoSpares.Services.Validations.ResourcesValidation;
using SmartAutoSpares.Services.Bookings;
using SmartAutoSpares.Services.Settings;
using SmartAutoSpares.Hubs.Cart;
using SmartAutoSpares.Hubs.Notifications;
using Microsoft.OpenApi.Models;
using SmartAutoSpares.Services.Applications;
using SmartAutoSpares.Services.Validations.CartValidations;

namespace SmartAutoSpares
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
            services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:5000", "http://localhost:5200", "http://localhost:3000", "https://aspnetclusters-89879-0.cloudclusters.net")
                        .AllowCredentials();
                });
            });

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.4",
                    Title = "Smart Auto Spares API",
                    Description = "An ASP.NET Core Web API for managing Smart Auto Spares App"
                });
                options.CustomSchemaIds(type => type.ToString());
            });

            services.AddControllers();

            services.AddDbContext<SmartAutoSparesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(Configuration.GetSection("Environment").Value)));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICartValidationService, CartValidationService>();

            services.AddScoped<IAutoSparesService, AutoSparesService>();
            services.AddScoped<IHandler, Handler>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IResourcesValidation, ResourcesValidation>();
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<IAuthenticationValidation, AuthenticationValidation>();
            services.AddScoped<IApplicationsService, ApplicationsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("ClientPermission");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<AutoSparesHub>("/hubs/auto-spares");
                endpoints.MapHub<CartHub>("/hubs/cart");
                //endpoints.MapHub<BookingsHub>("/hubs/bookings");
                //endpoints.MapHub<ResourcesHub>("/hubs/resources");
                //endpoints.MapHub<NotificationsHub>("/hubs/notifications");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Auto Spares API V1");
            });
        }
    }
}
