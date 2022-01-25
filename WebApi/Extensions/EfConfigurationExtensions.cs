using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class EfConfigurationExtensions
    {
        public static void ApplyEfConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var implementedConfigTypes = assembly
                .GetTypes()
                .Where(t => !t.IsAbstract
                            && !t.IsGenericTypeDefinition
                            && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
                                i.GetTypeInfo().IsGenericType &&
                                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var configType in implementedConfigTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }
        }
    }
}