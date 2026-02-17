public class MenuPoints
{

    public List<(string, string)> mainMenuPoints = new()
    {
        ("n", "new"),
        ("l", "load"),
        ("s", "save"),
        ("x", "exit")
    };

    public List<(string, string)> steeringMenuPoints = new()
    {
        ("e", "edit"),
        ("s", "search"),
        ("b", "back")
    };

    public List<(string, string)> editMenu = new()
    {
        ("e", "edit"),
        ("n", "new"),
        ("b", "back")
    };

    public List<(string, string)> menuYesNo = new()
    {
        ("y", "yes"),
        ("n", "no")
    };
}
