public static class Program
{
    public static void Main()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        LabelImporter labelImporter = new();

        SettingImporter setting = new();
        
        labelImporter.Starter(setting.path);
    }
}
