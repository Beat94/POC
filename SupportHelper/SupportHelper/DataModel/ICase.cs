public interface ICase
{
    public List<string> CreateMenu();
    public string GetName();
    public void SetName(string inputString);
    public void AddPoint(object name);
    public object getObject(int pointer);
    public void DelAtPoint(int pointer);
    public object CreateNewChild();
}