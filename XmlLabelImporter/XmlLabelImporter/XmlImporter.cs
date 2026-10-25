using System.Xml.Serialization;
using System;

public class XmlImporter
{
    public List<SqlDataModel> MassImport(string path)
    {
        List<SqlDataModel> sqlDataModels = new List<SqlDataModel>();

        if(string.IsNullOrEmpty(path))
        {
            string exceptionMessage = $"Variable {nameof(path)} is null or empty";
            //Console.WriteLine(exceptionMessage);
            throw new Exception(exceptionMessage);    
        }   

        List<string> fileList = Directory.GetFiles(path).ToList();

        Console.WriteLine(".");
        foreach(string fileItem in fileList)
        {
            Console.WriteLine(fileItem);
        }
        Console.WriteLine(".");

        if(fileList.Count() == 0)
        {
            string exceptionMessage = $"Folder {path} is empty";
            //Console.WriteLine(exceptionMessage);
            throw new Exception(exceptionMessage);
        }
        
        List<string> filenameStringArray;

        foreach(string filename in fileList)
        {
            filenameStringArray = filename.Split("_").ToList();
            sqlDataModels.AddRange(
                Import(filename, 
                    filenameStringArray[0], 
                    filenameStringArray[1]));
        }

        return sqlDataModels;
    }

    // single import from xml to Datamodel
    public List<SqlDataModel> Import(string pathWithFilename, string instanzname, string sprache)
    {
        sprache = sprache.Split(".")[0];
        List<SqlDataModel> outputList = new();

        XmlSerializer serializer = new XmlSerializer(typeof(Sysconfig));

        using FileStream stream = File.OpenRead(pathWithFilename);
        Sysconfig? config = (Sysconfig)serializer.Deserialize(stream);

        if (config == null || string.IsNullOrEmpty(config.LabelContent))
        {
            throw new Exception("Config is null or empty");
        }

        string cdata = config.LabelContent;

        // here comes translation logic from xml to datamodel
        var lines = cdata.Split("\n");

        string[] lineSplit;
        SqlDataModel oneItem;

        foreach(var line in lines)
        {
            var trimmed = line.Trim();

            string trimmed2 = ignoreLinesStartsWithChar('#', trimmed);


            if(!string.IsNullOrEmpty(trimmed2))
            {
                lineSplit = trimmed2.Split(new[]{'='}, 2);

                oneItem = new();
                oneItem.Instanzname = instanzname;
                oneItem.Sprache = sprache;
                oneItem.Label = lineSplit[0] ?? "";
                oneItem.Translation = lineSplit[1] ?? "";

                outputList.Add(oneItem);
            }
        }

        return outputList;
    }

    public string ignoreLinesStartsWithChar(char charItem, string input)
    => !string.IsNullOrEmpty(input) && input[0] == charItem ? string.Empty : input; 
}