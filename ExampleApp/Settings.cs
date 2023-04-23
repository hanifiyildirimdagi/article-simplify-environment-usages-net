using ExampleApp.Configuration;

namespace ExampleApp;

[ConfigVariable]
public class Settings
{
    [Variable("LOG_PREFIX", defaultValue:"MyApp")]
    public string LogPrefix { get; set; }
    [Variable("CONNECTION_STRING", required: true)]
    public string ConnectionString { get; set; }
}