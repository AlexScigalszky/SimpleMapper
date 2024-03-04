using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SimpleMapper.ServiceDiscovery
{
    public static class SimpleMapperDependecyInjection
    {
        public static IServiceCollection AddSimpleMapper(this IServiceCollection serviceCollection)
        {
            var assembly = Assembly.GetCallingAssembly() ?? Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            return serviceCollection.AddScoped<ISimpleMapper>(implementationFactory =>
            {
                var mapper = new SimpleMapper();
                
                var instances = types
                    .Where(t => t.GetInterfaces().Contains(typeof(IClassMapper)))
                    .Select(implementation => Activator.CreateInstance(implementation))
                    .Where(instance => instance is IClassMapper);

                foreach (var instance in instances)
                {
                    if (instance is IClassMapper classMapper)
                    {
                        classMapper.Bind(mapper);
                    }
                }

                return mapper;
            });
        }
    }
}
