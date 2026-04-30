namespace XmlLabelImporterTest;

public class XmlLabelImporterTest
{
    string link = ".\\..\\..\\..\\..\\XmlLabelImporterTest\\TestDatas";

    [Theory]
    [InlineData("TestInstanz_de.xml")]
    public void Test1(string filename)
    {
        XmlImporter xmlImporter = new();
        SqlDataModel output = xmlImporter.Import($"{link}\\{filename}");
        Assert.Equal(true, true);
    }
}
