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
}