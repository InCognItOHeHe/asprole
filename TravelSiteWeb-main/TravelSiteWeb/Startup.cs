using TravelSiteWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Services;
using FluentValidation;
using TravelSiteWeb.Models;

namespace TravelSiteWeb
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TripContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IClientsRepository, ClientsRepository>();
            // Register IClientRepository with its implementation ClientRepository
            // Register IClientRepository with its implementation ClientRepository
            // services.AddScoped(typeof(IPaginatedList<>), typeof(PaginatedList<>));
            
            services.AddScoped(typeof(IPaginatedListService), typeof(PaginatedListService));
            services.AddControllersWithViews();
            services.AddControllersWithViews();
            services.AddScoped<IDestinationsRepository, DestinationsRepository>();
            services.AddScoped<IReservationsRepository, ReservationsRepository>();
            services.AddSingleton<MappingService>();
            var mappingService = services.BuildServiceProvider().GetRequiredService<MappingService>();
            mappingService.ConfigureMapping();
            //Injecting validators
            services.AddScoped<IValidator<Clients>, ClientValidator>(); //Client validator
            services.AddScoped<IValidator<Reservations>, ReservationValidator>(); //Reservation validator
            services.AddScoped<IValidator<Destinations>, TravelDestinationValidator>(); //TravelDestination validator
        }
    }
}