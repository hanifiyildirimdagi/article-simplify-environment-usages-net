using ExampleApp;

var builder = WebApplication.CreateBuilder(args);

var settings = new Settings
{
    LogPrefix = Environment.GetEnvironmentVariable("LOG_PREFIX"),
    ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
};

if(string.IsNullOrEmpty(settings.ConnectionString)) throw new Exception("LOG_PREFIX value is required for the application");
settings.LogPrefix ??= "MyApp";

builder.Services.AddSingleton<Settings>(settings);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
