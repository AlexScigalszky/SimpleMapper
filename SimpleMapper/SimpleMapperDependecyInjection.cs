﻿using Microsoft.Extensions.DependencyInjection;
using SimpleMapper;
using System.Reflection;

namespace Mappear
{
    public static class SimpleMapperDependecyInjection
    {
        public static void AddSimpleMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(implementationFactory =>
            {
                var mapper = new SimpleMapper();
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