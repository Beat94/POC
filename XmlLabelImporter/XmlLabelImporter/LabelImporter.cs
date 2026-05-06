public class LabelImporter
{
    private XmlImporter xmlImporter = new();
    // Here happens the magic

    public void Starter(string path)
    {
        // Load from settings-file
        List<SqlDataModel> listDatas = xmlImporter.MassImport(path);
        
        Console.WriteLine("Message out of LabelImporter class");
    }
}