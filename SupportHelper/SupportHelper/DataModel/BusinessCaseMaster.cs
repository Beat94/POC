public class BusinessCaseMaster : ICase
{
    public List<BusinessCase> businessCaseList;

    public List<string> CreateMenu()
    {
        List<string> output = new();
        businessCaseList.ForEach(x => output.Add(x.BusinessCaseName));
        return output;
    }

    public string GetName()
    {
        throw new NotImplementedException();
    }

    public void SetName(string? readLine)
    {
        throw new NotImplementedException();
    }

    public void AddPoint(object name)
    {
        businessCaseList.Add((BusinessCase) name);
    }

    public object getObject(int pointer)
        => businessCaseList[pointer];

    public void DelAtPoint(int pointer)
    {
        businessCaseList.RemoveAt(pointer);
    }

    public object CreateNewChild()
    => new BusinessCase { topics = new List<Topic>() };
}