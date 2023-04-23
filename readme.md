# Example Settings Configuration with Environment Variables in .NET

This project is a sample implementation of a settings configuration in a .NET Core console application using environment variables. It demonstrates how to use attributes to define settings variables and how to dynamically set their values at runtime using reflection.

## Getting Started

To get started, clone this repository to your local machine.

### Usage

To use this project as a starting point for your own settings configuration, follow these steps:

1. Define your settings variables in a class. You can use the `VariableAttribute` to define each variable's key, default value, and whether it is required.
   Example;

```C#
[ConfigVariable]
public class Settings
{
    [Variable("API_KEY", required: true)]
    public string ApiKey { get; set; }
    [Variable("API_URL", defaultValue: "https://api.example.com")]
    public string ApiUrl { get; set; }
}
```

2. Use the `ConfigVariableAttribute` to mark your class so that it can be detected by the settings configuration.

3. Call the `ConfigureConfigs` extension method on the `IServiceCollection` instance in the `ConfigureServices` method of your `Startup` class to configure the settings.
