using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

public class SettingImporter
{
    public IConfiguration configuration { get; }
    public string baseFolderPath { get; }
    public string databasePath { get; }

    public SettingImporter(string pathToSettingFile)
    {
        if (!File.Exists(pathToSettingFile))
        {
            Console.WriteLine("There is no settings-File");
            return;
        }
        
        var configBuilder = new ConfigurationBuilder().SetBasePath(pathToSettingFile).AddJsonFile("appsettings.json");
        configuration = configBuilder.Build();
        baseFolderPath = configuration["baseFolderPath"];
        databasePath = configuration["databasePath"];
    }
}
