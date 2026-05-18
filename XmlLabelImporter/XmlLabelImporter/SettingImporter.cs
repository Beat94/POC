using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

public class SettingImporter
{
    public IConfiguration configuration { get; }
    public string baseFolderPath { get; }
    public string databasePath { get; }

    public SettingImporter(string pathToSettingFile)
    {
        string settingsfile = "appsettings.json";
        string path2 = $"{pathToSettingFile}\\{settingsfile}";

        if (!File.Exists(path2))
        {
            Console.WriteLine("There is no settings-File");
            Console.WriteLine(path2);
            return;
        }
        
        var configBuilder = new ConfigurationBuilder().SetBasePath(pathToSettingFile).AddJsonFile(settingsfile);
        configuration = configBuilder.Build();
        baseFolderPath = configuration["baseFolderPath"];
        databasePath = configuration["databasePath"];
    }
}
