public class LabelImporter
{
    private XmlImporter xmlImporter = new();
    // Here happens the magic

    public void Starter(string basePath, string databasePath)
    {
        List<SqlDataModel> listDatas = xmlImporter.MassImport(basePath);

        SqliteHandler sqliteHandler = new SqliteHandler(databasePath);
        sqliteHandler.InsertIntoTable(listDatas);
    }
}