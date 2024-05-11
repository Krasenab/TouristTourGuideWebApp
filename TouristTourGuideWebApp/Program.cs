using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services;
using TouristTourGuide.Services.Interfaces;
using static TouristTourGuide.Infrastrucutre.WebAppBuilderExtensions;
namespace TouristTourGuideWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<TouristTourGuideDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
               {
                   options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequiredConfirmedAccount");
                   options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                   options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                   options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                   options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");

               }
            )
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<TouristTourGuideDbContext>();

            builder.Services.AddApplicationServices(typeof(ITourService));
            builder.Services.AddApplicationServices(typeof(ILocationService));
            builder.Services.AddApplicationServices(typeof(IGuideUserService));
            builder.Services.AddApplicationServices(typeof(IImageService));
            builder.Services.AddApplicationServices(typeof(ICommentsService));
           
          


            // MongoDB  
            var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
            var mongoClient = new MongoClient(mongoConnectionString);
            
            builder.Services.AddSingleton<IMongoDatabase>(mongoClient.GetDatabase("TouristTourGuideWebApp"));
        

            builder.Services.AddControllersWithViews();
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
           
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
