public static class Program
{
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        
        
        LabelImporter labelImporter = new();

        SettingImporter setting = new("Dieser pfad");
        
        labelImporter.Starter(setting.baseFolderPath, setting.databasePath);
    }
}
