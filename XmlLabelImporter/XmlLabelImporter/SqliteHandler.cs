using System.Data;
using Microsoft.Data.Sqlite;

public class SqliteHandler
{
    private string saveplace;
    
    private string createTableNotExistQuery = 
        "create table if NOT EXISTS tbl_Label (" +
        "ID_Label Integer PRIMARY KEY AUTOINCREMENT,Instanzname text,Labelname text,Sprache text,Translation text);";
    
    private string insertIntoQuery = "Insert into tbl_label (Instanzname, Labelname, Sprache, Translation) values ";
    

    public SqliteHandler(string link)
    {
        // it depends if the passing parameter is a isettings thing or not
        saveplace = link;
        LoadDatabase();
    }
    
    public void QueryExecuter(string query)
    {
        try
        {
            using var connection = new SqliteConnection($"Data Source={saveplace}");
            connection.Open();
        
            // Create table
            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery(); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public string CreateInsertIntoTableQuery(List<SqlDataModel> inputList)
    {
        string output = String.Empty;

        int indexer = 0;
        int arrayLength = inputList.Count();
        
        foreach (SqlDataModel inputItem in inputList)
        {
            output += $"( '{Escape(inputItem.Instanzname)}', '{Escape(inputItem.Label)}', '{Escape(inputItem.Sprache)}', " +
                    $"'{Escape(inputItem.Translation)}')";

            if (indexer < arrayLength - 1)
            {
                output += ",";
            }
            
            indexer++;
        }

        output += ";";
        
        return insertIntoQuery + output;
    }
    
    private void LoadDatabase()
    {
        QueryExecuter(createTableNotExistQuery);
    }

    public void InsertIntoTable(List<SqlDataModel> inputList)
    {
        QueryExecuter(CreateInsertIntoTableQuery(inputList));
    }

    
    private string Escape(string input)
    {
        return input?.Replace("'", "''") ?? "";
    }
}