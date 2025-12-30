public class Topic : ICase
{
    public string topicName;
    public List<string> solutions;

    /// <summary>
    /// it is not a classic menu
    /// </summary>
    /// <returns></returns>
    public List<string> CreateMenu()
    {
        List<string> output = new();
        solutions.ForEach(x => output.Add(x));
        return output;
    }
}