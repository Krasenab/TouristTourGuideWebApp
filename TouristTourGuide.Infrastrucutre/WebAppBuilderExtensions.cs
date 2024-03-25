﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

    }
}
