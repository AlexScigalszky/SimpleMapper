using Microsoft.Extensions.DependencyInjection;

namespace SimpleMapper.ServiceDiscovery
{
    public class SimpleMapperDependecyInjection
    {
        public static IServiceCollection AddSimpleMapper(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped(implementationFactory =>
            {
                var mapper = new SimpleMapper.SimpleMapper();
                var instances = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(IClassMapper)))
                    .Select(implementation => Activator.CreateInstance(implementation))
                    .Where(instance => instance is ISimpleMapper);

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
