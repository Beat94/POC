public class BusinessCase : ICase
{
    public string BusinessCaseName;
    public List<Topic> topics;

    public List<string> CreateMenu()
    {
        List<string> output = new();
        topics.ForEach(x => output.Add(x.topicName));
        return output;
    }

    public string GetName()
        => BusinessCaseName;

    public void SetName(string? inputString)
    {
        this.BusinessCaseName =  inputString;
    }

    public void AddPoint(object name)
    {
        topics.Add((Topic) name);
    }

    public object getObject(int pointer)
        => topics[pointer];

    public void DelAtPoint(int pointer)
    {
        topics.RemoveAt(pointer);
    }

    public object CreateNewChild()
    => new Topic { solutions = new List<string>() };
}