using System.Reflection;

namespace ExampleApp.Configuration;

public static class Extensions
{
    public static void ConfigureConfigs(this IServiceCollection services)
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        Type[] types = executingAssembly
            .GetTypes()
            .Where(type => type.GetCustomAttributes(typeof(ConfigVariableAttribute), true).Length > 0)
            .ToArray();

        string Read(VariableAttribute attribute)
        {
            return Environment.GetEnvironmentVariable(attribute.Key) ??
                   (attribute.Required ? throw new Exception($"{attribute.Key} value is required for the application.") : attribute.DefaultValue);
        }

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type)!;
            PropertyInfo[] properties = type
                .GetProperties()
                .Where(info => info.GetCustomAttributes(typeof(VariableAttribute), true).Any())
                .ToArray();

            foreach (var property in properties)
            {
                var attribute =
                    (VariableAttribute)property.GetCustomAttributes(typeof(VariableAttribute), true).First();
                property.SetValue(instance, Read(attribute));
            }

            services.AddSingleton(type, instance);
        }
    }
}