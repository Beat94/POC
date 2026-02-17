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

    public string GetName()
        => topicName;

    public void SetName(string inputString)
    {
        this.topicName = inputString;
    }

    public void AddPoint(object name)
    {
        solutions.Add(name.ToString());
    }

    public object getObject(int pointer)
        => solutions[pointer];

    public void DelAtPoint(int pointer)
    {
        solutions.RemoveAt(pointer);
    }

    public object CreateNewChild()
        => string.Empty;
}