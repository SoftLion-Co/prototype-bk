using System.Reflection;
using BLL.DTOs.ExceptionHandlers;

namespace API.Extensions;

public static class ExceptionExtension
{
    private static readonly Type UsedInterface = typeof(IExceptionHandler<>);
    
    public static IServiceCollection AddExceptionHandlers(this IServiceCollection serviceCollection,
        params Assembly[] assemblies)
    {
        var services = GetServices(assemblies);

        foreach (var serviceDescriptor in services)
        {
            serviceCollection.Add(serviceDescriptor);
        }

        return serviceCollection;
    }

    private static IEnumerable<Type> GetClasses(Assembly[] assemblies)
    {
        return assemblies.SelectMany(a => a.GetTypes())
            .Where(x => x.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == UsedInterface));
    }

    private static Dictionary<Type, Type> GetDictionary(Assembly[] assemblies)
    {
        var classes = GetClasses(assemblies);
        var dict = new Dictionary<Type, Type>();
        
        foreach (var clasType in classes)
        {
            var genericArguments = clasType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == UsedInterface)
                .Select(g => g.GetGenericArguments()).FirstOrDefault();

            if (genericArguments == null || genericArguments.Length != 1) 
                continue;
            
            var key = UsedInterface.MakeGenericType(genericArguments);
            dict[key] = clasType;
        }
        
        return dict;
    }

    private static IEnumerable<ServiceDescriptor> GetServices(Assembly[] assemblies)
    {
        var dict = GetDictionary(assemblies);
        var serviceDescriptors = new List<ServiceDescriptor>();

        foreach (var type in dict)
        {
            serviceDescriptors.Add(new ServiceDescriptor(type.Key, type.Value, ServiceLifetime.Singleton));
        }

        return serviceDescriptors;
    }
}