using Microsoft.Extensions.Configuration;

namespace Theatre.Infrastructure;

public class Configuration
{
    private const string ConfigurationFile = "appsettings.json";
    private const string ConfigurationStringName = "TheatreConnection";

    private readonly IConfigurationRoot _configRoot;

    public Configuration()
    {
        _configRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(ConfigurationFile).Build();
    }

    public string ConnectionString =>
        _configRoot.GetConnectionString(ConfigurationStringName) ??
        throw new NullReferenceException("Connection String is null or config dile doesn't exists");
}