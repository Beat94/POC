namespace XmlLabelImporterTest;

public class SqliteHandlerTest
{
    List<SqlDataModel> inputList = new()
    {
        new SqlDataModel()
        {
            Instanzname = "TestInstanz",
            Label = "text.title",
            Sprache = "de",
            Translation = "TestTitel"
        },
        new SqlDataModel()
        {
            Instanzname = "TestInstanz",
            Label = "text.title",
            Sprache = "fr",
            Translation = "BaguetteTitel"
        }
    };

    private string expectedInsertQuery = "Insert into tbl_label (Instanzname, Labelname, Sprache, Translation) " +
                                         "values( 'TestInstanz', 'text.title', 'de', 'TestTitel')," +
                                         "( 'TestInstanz', 'text.title', 'fr', 'BaguetteTitel');";
    
    [Fact]
    public void CreateTableInsertionStatementTest()
    {
        SqliteHandler sqliteHandler = new("");
        
        string result = sqliteHandler.CreateInsertIntoTableQuery(inputList);
        
        Assert.Equal(expectedInsertQuery, result);
    }
}