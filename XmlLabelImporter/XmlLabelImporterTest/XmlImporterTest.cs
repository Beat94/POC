namespace XmlLabelImporterTest;

public class XmlLabelImporterTest
{
    string link = ".\\..\\..\\..\\..\\XmlLabelImporterTest\\TestDatas";

    [Theory]
    [InlineData("TestInstanz_de.xml")]
    public void Test1(string filename)
    {
        XmlImporter xmlImporter = new();
        List<string> filenameStringArray = filename.Split("_").ToList();
        
        
        List<SqlDataModel> output = xmlImporter.Import($"{link}\\{filename}", 
            filenameStringArray[0], filenameStringArray[1]);
        Assert.Equal(true, true);
    }
}
