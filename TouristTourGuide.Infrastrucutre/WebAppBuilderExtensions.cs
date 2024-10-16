using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Infrastrucutre
{
    public static class WebAppBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, Type typeOfService)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(typeOfService);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("invalid type services");


            }

            Type[] serviceType = serviceAssembly.GetTypes().Where(t => t.Name.EndsWith("Service") && !t.IsInterface).ToArray();

            foreach (Type st in serviceType)
            {
                Type? currentInterfaceType = st.GetInterface($"I{st.Name}");

                if (currentInterfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name: {currentInterfaceType.Name}");
                }

                services.AddScoped(currentInterfaceType, st);
            }

        }
        //this method is asynhron and sinhrone ednovremeno
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string email)
        {
            // get providers of all scoped services and get all services that i need
            //get sservices provider to get dpencies injecson container bcose invsenol contrl bcouse in STATIC u cant do this
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            IServiceProvider scopepedServicesProvider = scopedServices.ServiceProvider;
            UserManager<ApplicationUser> userManager = scopepedServicesProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleM = scopepedServicesProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
         
            Task.Run(async () =>
            {
                if (await roleM.RoleExistsAsync("Administrator")) 
                {
                    //ako tazi rola sushtestvuva ne pravi nishto return;
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>("Administrator");

                await roleM.CreateAsync(role);
                ApplicationUser admin = await userManager.FindByEmailAsync(email);
               
                await userManager.AddToRoleAsync(admin, "Administrator");
                

            }).GetAwaiter().GetResult(); // poslednite dva metoda mi gerantirat che sled prekluchvane na asinhrona shte produlji sinhroniq method 

            return app;
        }
        public static IApplicationBuilder EnebleOnlineUsersCheck(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<OnlineUsersMiddleware>();
        }

    }
  

}
